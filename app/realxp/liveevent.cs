//------------------------------------------------------------------------------
// [liveevent Model]
// Contains the liveevent object and it's properties.
//
// Author: Michael Walton
//------------------------------------------------------------------------------

namespace realxp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class liveevent
    {
        public liveevent()
        {
            this.user_purchase = new HashSet<user_purchase>();

            // set the liveevent_daterange property for use in views
            if ((this.liveevent_end_time - this.liveevent_start_time).TotalDays >= 1)
            {
                this.liveevent_daterange = this.liveevent_start_time.ToString("dd/MM/yyyy") + " - " + this.liveevent_end_time.ToString("dd/MM/yyyy");
            }
            else
            {
                this.liveevent_daterange = this.liveevent_start_time.ToString("dd/MM/yyyy");
            }
        }

        // set the properties and hard types and formatting
        public int liveeventID { get; set; }
        public int venueID { get; set; }
        // event name
        [DisplayName("Event Name"), DataType(DataType.Text), StringLength(100)]
        public string liveevent_name { get; set; }
        // start datetime
        //[DisplayName("Start Date"), DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [DisplayName("Start Date"), DataType(DataType.DateTime)]
        public System.DateTime liveevent_start_time { get; set; }
        // end datetime
        [DisplayName("End Date"), DataType(DataType.DateTime)]
        public System.DateTime liveevent_end_time { get; set; }
        // price
        [DisplayName("Price"), DataType(DataType.Currency)]
        public decimal liveevent_price { get; set; }
        // description
        [DisplayName("Description"), DataType(DataType.MultilineText), StringLength(250)]
        public string liveevent_description { get; set; }
        // promo image
        [DisplayName("Promotional Image"), DataType(DataType.Upload)]
        public string liveevent_image { get; set; }
        // stub for daterange property
        [DisplayName("Date"), DataType(DataType.Text), StringLength(250)]
        public string liveevent_daterange { get; set; }
    
        public virtual venue venue { get; set; }
        public virtual ICollection<user_purchase> user_purchase { get; set; }
    }
}
