using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.DTOs
{
    public class ServiceChargeUpdateHistoryDTO
    {

        public Guid Id { get; set; }
        public Guid GSTClientId { get; set; }

        public GSTClientDTO GSTClient { get; set; }
        public DateTime AmendedDate { get; set; }
        public int ReturnFrequencyTypeId { get; set; }
        public ReturnFrequencyTypeDTO ReturnFrequencyType { get; set; }
        public double PreviousRate { get; set; }
        public double NewRate { get; set; }



    }

    public class ServiceChargeUpdateHistoryCreateDTO
    {

        public Guid GSTClientId { get; set; }
        public DateTime AmendedDate { get; set; }
        public int ReturnFrequencyTypeId { get; set; }
        public double PreviousRate { get; set; }
        public double NewRate { get; set; }




        public class ServiceChargeUpdateHistoryUpdateDTO
        {
            public Guid Id { get; set; }
            public Guid GSTClientId { get; set; }
            public DateTime AmendedDate { get; set; }
            public int ReturnFrequencyTypeId { get; set; }
            public double PreviousRate { get; set; }
            public double NewRate { get; set; }



        }
    }
}
