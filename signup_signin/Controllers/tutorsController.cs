using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace signup_signin.Controllers
{
    public class tutorsController : ApiController
    {

        [AllowAnonymous]

        [HttpGet]
        [Route("api/tutors")]


        public IEnumerable<tbl_tutor> Get()
        {
            using (tutorEntities entities = new tutorEntities())
            {

                return entities.tbl_tutor.ToList();

            }





        }


        public tbl_tutor Get(int id)
        {
            using (tutorEntities entities = new tutorEntities())
            {

                return entities.tbl_tutor.FirstOrDefault(t => t.ID == id);

            }


        }


        [HttpPost]
        [Route("api/tutors")]


        public HttpResponseMessage Post([FromBody] tbl_tutor tutor)
        {
            try
            {
                using (tutorEntities entities = new tutorEntities())
                {

                    entities.tbl_tutor.Add(tutor);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.OK,"Tutor data has been added successfuly!");
                    message.Headers.Location = new Uri(Request.RequestUri + tutor.ID.ToString());
                    return message;
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);

            }

        }


        [HttpDelete]

        public HttpResponseMessage Delete(int id)
        {

            try
            {


                using (tutorEntities entities = new tutorEntities())
                {

                    var entity = entities.tbl_tutor.Remove(entities.tbl_tutor.FirstOrDefault(t => t.ID == id));


                    if (entity == null)
                    {

                        return Request.CreateResponse(HttpStatusCode.NotFound, "Tutor with ID=" + id.ToString() + "not found to be deleted");
                    }
                    else
                    {
                        entities.tbl_tutor.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Tutor with ID=" + id.ToString() + " has been successfuly deleted");
                    }


                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

            }

        }


        [HttpPut]

        public HttpResponseMessage Put(int id, [FromBody]tbl_tutor tutor)
        {

            try
            {

                using (tutorEntities entities = new tutorEntities())
                {

                    var entity = entities.tbl_tutor.FirstOrDefault(t => t.ID == id);

                    if (entity == null)
                    {


                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tutor with ID=" + id.ToString() + "not found to be updated");
                    }


                    else
                    {

                        entity.ID = tutor.ID;
                        entity.City = tutor.City;
                        entity.Qualified = tutor.Qualified;
                        entity.Experience = tutor.Experience;
                        entity.Subjects = tutor.Subjects;
                        entity.Classes = tutor.Classes;
                        entity.Available = tutor.Available;
                        entity.Description = tutor.Description;
                        entity.Name = tutor.Name;
                        entity.Gender = tutor.Gender;
                        entity.Email = tutor.Email;
                        entity.Address = tutor.Address;
                        entity.Dob = tutor.Dob;

               

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Tutor with ID=" + id.ToString() + " has been successfuly updated");
                    }
                }
            }

            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

            }
        }



    }
}
