using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace signup_signin.Controllers
{
    public class studentsController : ApiController
    {
        [HttpGet]
        [Route("api/students")]


        public IEnumerable<tbl_student> Get()
        {
            using (tutorEntities entities = new tutorEntities())
            {

                return entities.tbl_student.ToList();

            }





        }


        public tbl_student Get(int id)
        {
            using (tutorEntities entities = new tutorEntities())
            {

                return entities.tbl_student.FirstOrDefault(t => t.id == id);

            }


        }


        [HttpPost]
        [Route("api/students")]


        public HttpResponseMessage Post([FromBody] tbl_student tutor)
        {
            try
            {
                using (tutorEntities entities = new tutorEntities())
                {

                    entities.tbl_student.Add(tutor);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.OK, "Student data has been added successfuly!");
                    message.Headers.Location = new Uri(Request.RequestUri + tutor.id.ToString());
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

                    var entity = entities.tbl_student.Remove(entities.tbl_student.FirstOrDefault(t => t.id == id));


                    if (entity == null)
                    {

                        return Request.CreateResponse(HttpStatusCode.NotFound, "Student with ID=" + id.ToString() + "not found to be deleted");
                    }
                    else
                    {
                        entities.tbl_student.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Student with ID=" + id.ToString() + " has been successfuly deleted");
                    }


                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

            }

        }


        [HttpPut]

        public HttpResponseMessage Put(int id, [FromBody]tbl_student tutor)
        {

            try
            {

                using (tutorEntities entities = new tutorEntities())
                {

                    var entity = entities.tbl_student.FirstOrDefault(t => t.id == id);

                    if (entity == null)
                    {


                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with ID=" + id.ToString() + "not found to be updated");
                    }


                    else
                    {

                        entity.id = tutor.id;
                        entity.City = tutor.City;
                        entity.Class = tutor.Class;
                        entity.Description = tutor.Description;
                        entity.Subjects = tutor.Subjects; 
                        entity.Name = tutor.Name;
                        entity.Gender = tutor.Gender;
                        entity.Email = tutor.Email;
                        entity.Address = tutor.Address;
                        entity.Dob = tutor.Dob;



                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Student with ID=" + id.ToString() + " has been successfuly updated");
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
