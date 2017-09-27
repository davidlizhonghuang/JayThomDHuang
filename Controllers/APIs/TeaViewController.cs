using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebJayThomDhuang.ViewModels;

namespace WebJayThomDhuang.Controllers.APIs
{
    public class TeaViewController : ApiController
    {
        private TeaEntities db = new TeaEntities();

        // GET: api/TeaView
        public IQueryable<TeaViewModel> GetTeaViewModels()
        {
            return db.TeaViewModels;
        }

        // GET: api/TeaView/5
        [ResponseType(typeof(TeaViewModel))]
        public async Task<IHttpActionResult> GetTeaViewModel(int id)
        {
            TeaViewModel teaViewModel = await db.TeaViewModels.FindAsync(id);
            if (teaViewModel == null)
            {
                return NotFound();
            }

            return Ok(teaViewModel);
        }

        // PUT: api/TeaView/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeaViewModel(int id, TeaViewModel teaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teaViewModel.ID)
            {
                return BadRequest();
            }

            db.Entry(teaViewModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeaViewModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TeaView
        [ResponseType(typeof(TeaViewModel))]
        public async Task<IHttpActionResult> PostTeaViewModel(TeaViewModel teaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeaViewModels.Add(teaViewModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = teaViewModel.ID }, teaViewModel);
        }

        // DELETE: api/TeaView/5
        [ResponseType(typeof(TeaViewModel))]
        public async Task<IHttpActionResult> DeleteTeaViewModel(int id)
        {
            TeaViewModel teaViewModel = await db.TeaViewModels.FindAsync(id);
            if (teaViewModel == null)
            {
                return NotFound();
            }

            db.TeaViewModels.Remove(teaViewModel);
            await db.SaveChangesAsync();

            return Ok(teaViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeaViewModelExists(int id)
        {
            return db.TeaViewModels.Count(e => e.ID == id) > 0;
        }
    }
}