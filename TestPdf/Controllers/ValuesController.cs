using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using TestPdf.Utils;

namespace TestPdf.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IViewRenderService _viewRenderService;
        private readonly IConverter _converter;

        public ValuesController(IViewRenderService viewRenderService,
            IConverter converter)
        {
            _viewRenderService = viewRenderService;
            _converter = converter;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var doc = PdfUtils.GetPage();

            var result =
                await _viewRenderService.RenderToStringAsync("Report/Test", id);

            doc.Objects.Add(new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = result,
                HeaderSettings =
                {
                    FontSize = 9,
                    Right = $"POLIEDRO | {id}",
                    Spacing = 0
                }
            });

            var data = _converter.Convert(doc);

            return File(data, "application/pdf", "myFile.pdf");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
