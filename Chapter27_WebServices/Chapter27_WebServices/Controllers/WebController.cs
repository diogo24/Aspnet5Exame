using Chapter27_WebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chapter27_WebServices.Controllers
{
    public class WebController : ApiController
    {
        private readonly ReservationRepository _reservationRepository = ReservationRepository.Current;

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAll();
        }

        public Reservation GetReservation(int id)
        {
            return _reservationRepository.Get(id);
        }

        //public Reservation PostReservation(Reservation reservation)
        //{
        //    return _reservationRepository.Add(reservation);
        //}
        [HttpPost]
        public Reservation CreateReservation(Reservation item)
        {
            return _reservationRepository.Add(item);
        }

        //public bool PutReservation(Reservation reservation)
        //{
        //    return _reservationRepository.Update(reservation);
        //}
        [HttpPut]
        public bool UpdateReservation(Reservation item)
        {
            return _reservationRepository.Update(item);
        }

        public void DeleteReservation(int id)
        {
            _reservationRepository.Remove(id);
        }
    }
}
