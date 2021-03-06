﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Thammapirom.Models;

namespace Thammapirom.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<WelcomeImage> WelcomeImages { get; set; }
        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ActivityClip> ActivityClips { get; set; }
        public DbSet<DhammaQA> DhammaQAs { get; set; }
        public DbSet<OtherEvent> OtherEvents { get; set; }
        public DbSet<AnnualEvent> AnnualEvents { get; set; }
        public DbSet<CustomEvent> CustomEvents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }

}                                                                                                                                                                                                                                                                                                                                                                          