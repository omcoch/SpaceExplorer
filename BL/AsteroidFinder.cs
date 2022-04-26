using DAL;
using DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class AsteroidFinder
    {
        private AsteroidHandler DAL;


        public AsteroidFinder()
        {
            DAL = new AsteroidHandler();
        }
        /// <summary>
        /// if there isn't nasa Astroid with this id returns null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<AsteroidCloseApproach> GetAsteroid(string id)
        {
            try
            {
                return DAL.GetAsteroidById(id);
            }
            catch (Exception)
            {
                return null;
                
            }
          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StartDate">Should be today to get today result.</param>
        /// <param name="EndDate">if not null Must be up to 7 days away from Start Day</param>
        /// <param name="IsDangerous">Optional</param>
        /// <param name="DiameterInKm">Optional</param>
        /// <returns>
        ///  if no exception  is thrown returns IEnumerable<Asteroid> else Null
        /// </returns>        
        public IEnumerable<Asteroid> GetAsteroids(DateTime StartDate, DateTime EndDate, bool IsDangerous=false, double DiameterInKm=0)
        {
            if (StartDate == DateTime.Now)
                return DAL.GetAsteroidsForToday(IsDangerous, DiameterInKm);
            else
            {
                try
                {
                    return DAL.GetAsteroids(StartDate, EndDate, IsDangerous, DiameterInKm);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

    }
}
