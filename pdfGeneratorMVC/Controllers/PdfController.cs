using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pdfGeneratorMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace pdfGeneratorMVC.Controllers
{
    [Route("mvc/[controller]")]
    public class PdfController : Controller
    {
        private readonly PdfContext context;
        public PdfController(PdfContext context)
        {
            this.context=context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
               return Ok(context.product.ToList());
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message+ex.StackTrace);
            }
        }

        [HttpGet("{id}", Name ="GetProduct")]
        // GET: Pdf/Details/5
        public ActionResult Get(int id)
        {
            try
            {
                var producto=context.product.FirstOrDefault(g=> g.id==id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] PdfModel product)
        {
            try
            {
                    context.product.Add(product);
                    context.SaveChanges();
                    //return CreateAtRoute("GetProduct", new { id=product.id },product );
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody]PdfModel product)
        {
            try
            {
                context.Entry(product).State=EntityState.Modified;
                context.SaveChanges();
                //return CreateAtRoute("GetProduct", new{id=product.id},product );
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        // POST: Pdf/Delete/5
        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var product =context.product.FirstOrDefault(g=>g.id==id);
                if(product!=null)
                {
                  context.product.Remove(product);
                  context.SaveChanges();
                  return Ok(id);
                }
                else {

                return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Pdf
        public ActionResult Index()
        {
            return View();
        }
    }
}