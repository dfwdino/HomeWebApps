namespace GroceryStoreAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase, IDisposable
    {
        private readonly GroceryStoreAPI.Models.GrocerySToreAPI groceryStoreAPI =
            new Models.GrocerySToreAPI();

        // GET: api/<StoreController>
        [HttpGet]
        public JsonResult Get()
        {
            var Stores = this.groceryStoreAPI.Stores.Select(m => m.Name);

            var convert = JsonConvert.SerializeObject(Stores);

            return new JsonResult(convert);
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StoreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            if (this.CheckForStore(value).Equals(false))
            {
                this.groceryStoreAPI.Add(new Models.Store { Name = value });

                this.groceryStoreAPI.SaveChanges();
            }
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Models.Store store = GetStore(id);

            if (store == null)
            {
                return new Models.JsonErrorResult(
                    new { message = "No Store Found." },
                    HttpStatusCode.NotFound
                );
            }
            else
            {
                store.Deleted = true;
                groceryStoreAPI.SaveChanges();

                return new JsonResult(new { StatusCode = HttpStatusCode.OK });
            }
        }

        public void Dispose() { }

        private Models.Store GetStore<T>(T storeinfo)
        {
            int StoreID = 0;
            string StoreName = storeinfo.ToString();

            bool WasInt = Int32.TryParse(StoreName, out StoreID);

            if (WasInt)
            {
                return groceryStoreAPI.Stores.FirstOrDefault(m => m.StoreId == StoreID);
            }
            else
            {
                return groceryStoreAPI.Stores.FirstOrDefault(m => m.Name == StoreName);
            }
        }

        private bool CheckForStore<T>(T name)
        {
            int StoreID = 0;
            string StoreName = name.ToString();

            bool WasInt = int.TryParse(StoreName, out StoreID);

            if (WasInt)
            {
                return groceryStoreAPI.Stores.Any(m => m.StoreId == StoreID);
            }
            else
            {
                return groceryStoreAPI.Stores.Any(m => m.Name == StoreName);
            }
        }
    }
}
