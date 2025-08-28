using System.Net;

namespace ForParts.DTOs.Zureo
{
    public class ZureoResponseDto
    {

        public bool Success { get; internal set; }
        public string Raw { get; set; }
        public string Message { get; set; }
       
    }
}
