using System;

namespace Papara_cohort.DTO
{
    // Bu sınıf API yanıtlarını temsil eder
    public class ApiResponse<T>
    {
        public T Data { get; set; } // Yanıtın veri kısmı
        public bool Success { get; set; } // İşlemin başarılı olup olmadığını belirtir
        public string Message { get; set; } // Yanıt ile ilgili mesaj veya hata açıklaması
        public int StatusCode { get; set; } // HTTP durum kodu

        // Başarılı bir yanıt oluşturur
        public ApiResponse(T data)
        {
            Data = data;
            Success = true;
            StatusCode = 200; // Varsayılan olarak 200 OK
        }

        // Başarısız bir yanıt oluşturur
        public ApiResponse(string message, int statusCode = 400)
        {
            Message = message;
            Success = false;
            StatusCode = statusCode;
        }

        // Boş bir yanıt oluşturur
        public ApiResponse()
        {
            Success = true;
            StatusCode = 200; // Varsayılan olarak 200 OK
        }
    }

    // Hata yanıtı için kullanılacak temel sınıf
    public class ApiResponse
    {
        public bool Success { get; set; } // İşlemin başarılı olup olmadığını belirtir
        public string Message { get; set; } // Yanıt ile ilgili mesaj veya hata açıklaması
        public int StatusCode { get; set; } // HTTP durum kodu

        // Başarılı bir yanıt oluşturur
        public ApiResponse()
        {
            Success = true;
            StatusCode = 200; // Varsayılan olarak 200 OK
        }

        // Başarısız bir yanıt oluşturur
        public ApiResponse(string message, int statusCode = 400)
        {
            Message = message;
            Success = false;
            StatusCode = statusCode;
        }
    }
}
