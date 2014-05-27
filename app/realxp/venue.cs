//------------------------------------------------------------------------------
// [venue Model]
// Contains the venue object and it's properties.
//
// Author: Michael Walton
//------------------------------------------------------------------------------

namespace realxp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class venue
    {
        public venue()
        {
            this.seats = new HashSet<seat>();
            this.venue_review = new HashSet<venue_review>();
            this.liveevents = new HashSet<liveevent>();
        }
    
        public int venueID { get; set; }
        [DisplayName("Venue"), DataType(DataType.Text), StringLength(100)]
        public string venue_name { get; set; }
        [DisplayName("Country"), DataType(DataType.Text), StringLength(100)]
        public string venue_country { get; set; }
        [DisplayName("City"), DataType(DataType.Text), StringLength(100)]
        public string venue_city { get; set; }
        [DisplayName("State"), DataType(DataType.Text), StringLength(50)]
        public string venue_state { get; set; }
        [DisplayName("Address"), DataType(DataType.Text), StringLength(100)]
        public string venue_address_1 { get; set; }
        [DisplayName("Address Line 2"), DataType(DataType.Text), StringLength(100)]
        public string venue_address_2 { get; set; }
        [DisplayName("Address Line 3"), DataType(DataType.Text), StringLength(100)]
        public string venue_address_3 { get; set; }
        [DisplayName("Postcode"), DataType(DataType.PostalCode)]
        public string venue_postcode { get; set; }
        [DisplayName("Venue Image"), DataType(DataType.Text), StringLength(250)]
        public string venue_image { get; set; }
    
        public virtual ICollection<seat> seats { get; set; }
        public virtual ICollection<venue_review> venue_review { get; set; }
        public virtual ICollection<liveevent> liveevents { get; set; }
    }
}
