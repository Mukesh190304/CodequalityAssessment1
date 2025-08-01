
using CaptchaGeneratorService.Data;
using Microsoft.AspNetCore.Mvc;

namespace CaptchaGeneratorService.Model
{
    public class CaptchaGenerator
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        
    }
}