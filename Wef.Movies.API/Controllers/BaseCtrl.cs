using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Wef.Movies.API.Data;

namespace Wef.Movies.API.Controllers
{
    public class BaseCtrl : ControllerBase
    {
        public readonly JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
    }
}
