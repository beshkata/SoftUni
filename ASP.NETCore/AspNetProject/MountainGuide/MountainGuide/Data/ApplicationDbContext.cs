﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MountainGuide.Data
{
    public class MountainGuideDbContext : IdentityDbContext
    {
        public MountainGuideDbContext(DbContextOptions<MountainGuideDbContext> options)
            : base(options)
        {
        }
    }
}