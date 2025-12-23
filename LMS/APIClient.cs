using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelManagement.Desktop
{
    public class APIClient
    {
        private readonly HttpClient _http;

        public APIClient()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri("https://localhost:7018/");
        }

        // REGISTER
        public async Task<AuthResponse?> Register(RegisterRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/auth/register", request);
                string responseText = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Server Response: " + responseText);

                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Registration failed with status code: " + response.StatusCode);
                    return authResponse ?? new AuthResponse
                    {
                        Success = false,
                        Message = $"Registration failed: {response.StatusCode}"
                    };
                }

                return authResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during registration: " + ex.Message);
                return new AuthResponse
                {
                    Success = false,
                    Message = $"Exception: {ex.Message}"
                };
            }
        }

        // LOGIN
        public async Task<AuthResponse> Login(LoginRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/auth/login", request);

                string responseText = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Server Response: " + responseText);

                var authResponse = JsonSerializer.Deserialize<AuthResponse>(responseText);

                if (authResponse == null)
                    return new AuthResponse
                    {
                        Success = false,
                        Message = "Login failed (no response from API)"
                    };

                return authResponse;
            }
            catch (HttpRequestException ex)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "Cannot connect to API server. Make sure the API project is running.\n" + ex.Message
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "Exception during login: " + ex.Message
                };
            }
        }
    }

    // Model classes
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? FullName { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
    }

    public class RegisterRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}