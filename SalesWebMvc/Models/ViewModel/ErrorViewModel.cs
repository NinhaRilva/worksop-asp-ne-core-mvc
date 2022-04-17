using System;

namespace SalesWebMvc.Models.ViewModel
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; }

        // vai retona se não for nulo ou vazio
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}