using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI;
using BackboneSampe.DAL;
using BackboneSampe.Models;
using WebGrease.Css.Extensions;
using AutoMapper;
using BackboneSampe.ViewModels;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Hosting;
using System.Net.Http.Headers;

namespace BackboneSampe.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContryStateController : ApiController
    {
        private ContextClass cc = new ContextClass();

        public HttpResponseMessage GetDropDownValues(int cID = -1, int sID = -1)
        {
            //string countryName = "",string stateName = ""
            int activeCID = 0;
            //int activeSID = 0;

            var country = cc.Countries.ToList();

            //var ccs = country.Where(_ => _.CountryID == cID).SingleOrDefault();

            //////var state = cc.States.Where(_ => _.CountryID == cID);
            //if (ccs != null)
            //{
            //    cc.Entry(ccs).Collection(_ => _.State).Load();
            //}



            Mapper.CreateMap<Country, CountryViewModel>().ForMember(dest => dest.State, opt => opt.Ignore());
            List<CountryViewModel> ListcViewModel = Mapper.Map<List<CountryViewModel>>(country);

            var state = cc.States.Where(c => c.CountryID == cID).ToList();
            List<StateViewModel> ListsViewModel = null;
            if (state.Count > 0 || state != null)
            {
                Mapper.CreateMap<State, StateViewModel>().ForMember(dest => dest.Country, opt => opt.Ignore());
                ListsViewModel = Mapper.Map<List<StateViewModel>>(state);
                var imgPath = Directory.GetFiles("C:\\DotNet Practise\\BackboneExamples\\BackboneSampe\\BackboneSampe\\Images", "*");

                foreach(var ViewModels in ListsViewModel)
                {
                    if(ViewModels.ImageName!=null)
                    {
                        foreach (var imgName in imgPath)
                        {
                            if (imgName.Contains(ViewModels.ImageName))
                            {
                                ViewModels.ImageSrc = imgName;
                            }
                        }
                    }
                   
                }

            }
           
            //foreach()
            activeCID = cID;
           // activeSID = sID;

            return Request.CreateResponse(HttpStatusCode.OK, new { countryList = ListcViewModel, stateList = ListsViewModel, activeCID});
        }

        public HttpResponseMessage GetImage(string img)
        {

            //var img = Image.
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var filePath = HostingEnvironment.MapPath("~/Images/" + img+".jpg");
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            Image image = Image.FromStream(fileStream);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");



            return result;

           
        }
    }
}
