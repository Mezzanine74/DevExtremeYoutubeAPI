using DevExtremeYoutubeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace DevExtremeYoutubeAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseApiController<TModelDal, TModel> : ApiController
        where TModelDal : IBaseDataAccess<TModel>, new()
        where TModel : class, new()
    {
        public TModelDal Dal;

        public BaseApiController()
        {
            Dal = new TModelDal();
        }

        // GET api/<controller>
        public IEnumerable<TModel> Get()
        {
            var test = Dal.GetList();

            return test;
        }
        // GET api/<controller>/5
        public TModel Get(int id)
        {
            return Dal.GetByPrimaryKey(id);
        }

        // POST api/<controller>
        public TModel Add(TModel model)
        {
            return Dal.Add(model);
        }

        public TModel Update(TModel model)
        {
            if (Dal.Update(model) > 0)
            {
                return model;
            }

            return null;

        }

        public int Delete(int id)
        {
            return Dal.Delete(Dal.GetByPrimaryKey(id));
        }

    }

}