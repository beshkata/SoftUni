using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MountainGuide.Infrastructure.Data;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Extentions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            //await MigrateDatabase(services);

            //await SeedUsers(services);

            //await SeedTouristBuildingType(services);

            //await SeedMountain(services);

            //await SeedPeak(services);

            //await SeedTouristAssociation(services);

            //await SeedTouristBuildingWithCoordinates(services);

            //await SeedImages(services);

            //await SeedCommentsAndAnnouncements(services);

            return app;
        }

        private static async Task SeedUsers(IServiceProvider services)
        {
            var data = services.GetRequiredService<MountainGuideDbContext>();
            var userManager =  services.GetService<UserManager<User>>();

            if (await data.Users.AnyAsync())
            {
                return;
            }

            User user = new User
            {
                UserName = "PetarPetrov",
                Email = "petar@petrov.bg",
            };
            var password = "petar123";

            var result = await userManager.CreateAsync(user, password);
        }

        private static async Task SeedCommentsAndAnnouncements(IServiceProvider services)
        {
            var data = services.GetRequiredService<MountainGuideDbContext>();
            var userManager = services.GetService<UserManager<User>>();
            User user = await userManager.FindByNameAsync("PetarPetrov");

            if (user == null)
            {
                return;
            }

            if (await data.Comments.AnyAsync())
            {
                return;
            }

            List<Comment> comments = new List<Comment>();
            List<Announcement> announcements = new List<Announcement>();

            TouristBuilding kozyaStena = data
                .TouristBuildings
                .Where(tb => tb.Name == "Kozya Stena")
                .First();
            if (kozyaStena != null)
            {
                Comment[] kozyaStenaComments = new[]
                {
                    new Comment
                    {
                        Content = "Kozya Stena is a Great hut",
                        User = user,
                        UserId = user.Id,
                        TouristBuilding = kozyaStena,
                        TouristBuildingId = kozyaStena.Id
                    },
                    new Comment
                    {
                        Content = "I Love Kozya Stena hut",
                        User = user,
                        UserId = user.Id,
                        TouristBuilding = kozyaStena,
                        TouristBuildingId = kozyaStena.Id
                    }
                };
                comments.AddRange(kozyaStenaComments);

                Announcement[] kozyaStenaAnnouncement = new[]
                {
                    new Announcement
                    {
                        Title = "Spring party",
                        Content = "Kozia Stena hut organizes a spring party on March 22, 2022!",
                        User = user,
                        UserId = user.Id,
                        TouristBuilding = kozyaStena,
                        TouristBuildingId = kozyaStena.Id

                    }
                };
                announcements.AddRange(kozyaStenaAnnouncement);
            }


            TouristBuilding eho = data
                .TouristBuildings
                .Where(tb => tb.Name == "Eho")
                .First();
            if (eho != null)
            {
                Comment[] ehoComments = new[]
                {
                    new Comment
                    {
                        Content = "Eho i a Great hut",
                        User = user,
                        UserId = user.Id,
                        TouristBuilding = eho,
                        TouristBuildingId = eho.Id
                    },
                    new Comment
                    {
                        Content = "I Love Eho hut",
                        User = user,
                        UserId = user.Id,
                        TouristBuilding = eho,
                        TouristBuildingId = eho.Id
                    }
                };
                comments.AddRange(ehoComments);

                Announcement[] ehoAnnouncement = new[]
                {
                    new Announcement
                    {
                        Title = "Renovations",
                        Content = "Eho hut will be closed on April 14 due to renovations!",
                        User = user,
                        UserId = user.Id,
                        TouristBuilding = eho,
                        TouristBuildingId = eho.Id

                    }
                };
                announcements.AddRange(ehoAnnouncement);
            }
            
            TouristBuilding pleven = data
                .TouristBuildings
                .Where(tb => tb.Name == "Pleven")
                .First();
            if (pleven != null)
            {
                Comment[] plevenComments = new[]
                {
                    new Comment
                    {
                        Content = "Pleven i a Great hut",
                        User = user,
                        UserId = user.Id,
                        TouristBuilding = pleven,
                        TouristBuildingId = pleven.Id
                    },
                    new Comment
                    {
                        Content = "I Love Pleven hut",
                        User = user,
                        UserId = user.Id,
                        TouristBuilding = pleven,
                        TouristBuildingId = pleven.Id
                    }
                };
                comments.AddRange(plevenComments);

                Announcement[] plevenAnnouncement = new[]
                {
                    new Announcement
                    {
                        Title = "Chess competition",
                        Content = "Pleven hut organizes a chess competition on April 20, 2022!",
                        User = user,
                        UserId = user.Id,
                        TouristBuilding = pleven,
                        TouristBuildingId = pleven.Id

                    }
                };
                announcements.AddRange(plevenAnnouncement);
            }

            await data.Announcements.AddRangeAsync(announcements);
            await data.Comments.AddRangeAsync(comments);
            await data.SaveChangesAsync();
        }

        private static async Task SeedImages(IServiceProvider services)
        {
            var data = services.GetRequiredService<MountainGuideDbContext>();

            if (await data.Images.AnyAsync())
            {
                return;
            }
            List<Image> pictures = new List<Image>();

            TouristBuilding kozyaStena = data
                .TouristBuildings
                .Where(tb => tb.Name == "Kozya Stena")
                .First();
            Image[] kozyaStenaPics = new[]
            {
                new Image
                {
                    Description = "Kozya Stena Hut",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/HijaKozyaStena2.jpg/1280px-HijaKozyaStena2.jpg",
                    TouristBuilding = kozyaStena,
                    TouristBuildingId = kozyaStena.Id
                },
                new Image
                {
                    Description = "Kozya Stena Hut",
                    ImageUrl = "https://oilaripi.com/bg/images/object=119/372.jpg?thumb=1&max_width=1004",
                    TouristBuilding = kozyaStena,
                    TouristBuildingId = kozyaStena.Id
                },
                new Image
                {
                    Description = "Kozya Stena Hut",
                    ImageUrl = "https://oilaripi.com/bg/images/object=119/373.jpg?thumb=1&max_width=1004",
                    TouristBuilding = kozyaStena,
                    TouristBuildingId = kozyaStena.Id
                }
            };

            pictures.AddRange(kozyaStenaPics);

            TouristBuilding eho = data
                .TouristBuildings
                .Where(tb => tb.Name == "Eho")
                .First();

            Image[] ehoPics = new[]
{
                new Image
                {
                    Description = "Eho Hut",
                    ImageUrl = "https://oilaripi.com/bg/images/object=38/153.jpg?thumb=1&max_width=1004",
                    TouristBuilding = eho,
                    TouristBuildingId = eho.Id
                },
                new Image
                {
                    Description = "Eho Hut",
                    ImageUrl = "https://oilaripi.com/bg/images/object=38/432.jpg?thumb=1&max_width=1004",
                    TouristBuilding = eho,
                    TouristBuildingId = eho.Id
                },
                new Image
                {
                    Description = "Eho Hut",
                    ImageUrl = "https://oilaripi.com/bg/images/object=38/431.jpg?thumb=1&max_width=1004",
                    TouristBuilding = eho,
                    TouristBuildingId = eho.Id
                }
            };

            pictures.AddRange(ehoPics);

            TouristBuilding touristBuildingPleven = data
                .TouristBuildings
                .Where(tb => tb.Name == "Pleven")
                .First();
            Image[] plevenPics = new[]
            {
                new Image
                {
                    Description = "Pleven Hut",
                    ImageUrl = "https://www.btsbg.org/sites/default/files/hiji/Hija_Pleven.gif",
                    TouristBuilding = touristBuildingPleven,
                    TouristBuildingId = touristBuildingPleven.Id
                },
                new Image
                {
                    Description = "Pleven Hut",
                    ImageUrl = "https://tripsjournal.com/wp-content/uploads/2016/09/hija-pleven-otpred.jpg",
                    TouristBuilding = touristBuildingPleven,
                    TouristBuildingId = touristBuildingPleven.Id
                },
                new Image
                {
                    Description = "Pleven Hut",
                    ImageUrl = "https://tripsjournal.com/wp-content/uploads/2016/09/hija-pleven.jpg",
                    TouristBuilding = touristBuildingPleven,
                    TouristBuildingId = touristBuildingPleven.Id
                }
            };

            pictures.AddRange(plevenPics);

            Peak vezhen = data
                .Peaks
                .Where(p => p.Name == "Vezhen")
                .First();

            Image[] vezhenPics = new[]
{
                new Image
                {
                    Description = "Vezhen Peak",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Vejen.jpg/1280px-Vejen.jpg",
                    Peak = vezhen,
                    PeakId = vezhen.Id
                },
                new Image
                {
                    Description = "Vezhen Peak",
                    ImageUrl = "https://img.haskovo.net//images/news_images/2018/10/28/orig-67930185022577640.jpg",
                    Peak = vezhen,
                    PeakId = vezhen.Id
                },
                new Image
                {
                    Description = "Vezhen Peak",
                    ImageUrl = "https://planinazavseki.com/wp-content/uploads/2020/08/staroplaninskoto-konche-vrah-vezhen_04-800x533.jpg",
                    Peak = vezhen,
                    PeakId = vezhen.Id
                }
            };

            pictures.AddRange(vezhenPics);

            Peak botev = data
                .Peaks
                .Where(p => p.Name == "Botev")
                .First();
            Image[] botevPics = new[]
            {
                new Image
                {
                    Description = "Botev Peak",
                    ImageUrl = "https://oilaripi.com/bg/images/object=447/209.jpg?thumb=1&max_width=1004",
                    Peak = botev,
                    PeakId = botev.Id
                },
                new Image
                {
                    Description = "Botev Peak",
                    ImageUrl = "https://oilaripi.com/bg/images/object=447/210.jpg?thumb=1&max_width=1004",
                    Peak = botev,
                    PeakId = botev.Id
                },
                new Image
                {
                    Description = "Botev Peak",
                    ImageUrl = "https://traveler-diary.com/content/uploads/2019/01/vrah-botev-2.jpg",
                    Peak = botev,
                    PeakId = botev.Id
                }
            };

            pictures.AddRange(botevPics);

            Peak musala = data
                .Peaks
                .Where(p => p.Name == "Musala")
                .First();
            Image[] musalaPics = new[]
            {
                new Image
                {
                    Description = "Musala Peak",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Musala_IMG_1447.jpg/1280px-Musala_IMG_1447.jpg",
                    Peak = musala,
                    PeakId = musala.Id
                },
                new Image
                {
                    Description = "Musala Peak",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b3/Musala.JPG/1280px-Musala.JPG",
                    Peak = musala,
                    PeakId = musala.Id
                },
                new Image
                {
                    Description = "Musala Peak",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b8/Musala_bg_30072011.JPG/1280px-Musala_bg_30072011.JPG",
                    Peak = musala,
                    PeakId = musala.Id
                }
            };

            pictures.AddRange(musalaPics);

            Peak malyovitsa = data
                .Peaks
                .Where(p => p.Name == "Malyovitsa")
                .First();

            Image[] malyovitsaPics = new[]
            {
                new Image
                {
                    Description = "Malyovitsa Peak",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ed/Malyovitsa-winter-ifb.JPG/1280px-Malyovitsa-winter-ifb.JPG",
                    Peak = malyovitsa,
                    PeakId = malyovitsa.Id
                },
                new Image
                {
                    Description = "Malyovitsa Peak",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Maliovitsa_54072.jpg/1280px-Maliovitsa_54072.jpg",
                    Peak = malyovitsa,
                    PeakId = malyovitsa.Id
                },
                new Image
                {
                    Description = "Malyovitsa Peak",
                    ImageUrl = "https://drumivdumi.com/wp-content/uploads/2017/07/2po_pytekata_9867.jpg",
                    Peak = malyovitsa,
                    PeakId = malyovitsa.Id
                }
            };

            pictures.AddRange(malyovitsaPics);

            Mountain staraPlanina = data
                .Mountains
                .Where(m => m.Name == "Stara planina")
                .First();
            Image[] staraPlaninaPics = new[]
            {
                new Image
                {
                    Description = "Stara planina mountain",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/b/bf/Triglav_massif%2C_Bulgaria.jpg",
                    Mountain = staraPlanina,
                    MountainId = staraPlanina.Id
                },
                new Image
                {
                    Description = "Stara planina mountain",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5c/Midzor2.jpg",
                    Mountain = staraPlanina,
                    MountainId = staraPlanina.Id
                },
                new Image
                {
                    Description = "Stara planina mountain",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/04/Cape-emine-dinev.jpg",
                    Mountain = staraPlanina,
                    MountainId = staraPlanina.Id
                }
            };

            pictures.AddRange(staraPlaninaPics);


            Mountain rila = data
                .Mountains
                .Where(m => m.Name == "Rila")
                .First();
            Image[] rilaPics = new[]
            {
                new Image
                {
                    Description = "Rila mountain",
                    ImageUrl = "https://www.obekti.bg/sites/default/files/styles/article_gallery/public/images/shutterstock_323530922.jpg?itok=X-IyziCq",
                    Mountain = rila,
                    MountainId = rila.Id
                },
                new Image
                {
                    Description = "Rila mountain",
                    ImageUrl = "https://www.obekti.bg/sites/default/files/styles/article_gallery/public/gallery/shutterstock_229185679_0.jpg?itok=arwp2sV3",
                    Mountain = rila,
                    MountainId = rila.Id
                },
                new Image
                {
                    Description = "Rila mountain",
                    ImageUrl = "https://www.obekti.bg/sites/default/files/styles/article_gallery/public/gallery/shutterstock_229185664.jpg?itok=Jbzp7ajj",
                    Mountain = rila,
                    MountainId = rila.Id
                }
            };

            pictures.AddRange(rilaPics);

            await data.AddRangeAsync(pictures);
            await data.SaveChangesAsync();
        }

        private static async Task SeedTouristBuildingWithCoordinates(IServiceProvider services)
        {
            var data = services.GetRequiredService<MountainGuideDbContext>();

            if (await data.TouristBuildings.AnyAsync())
            {
                return;
            }

            Mountain staraPlanina = data
                .Mountains
                .Where(m => m.Name == "Stara planina")
                .First();

            await data.TouristBuildings.AddRangeAsync(new[]
            {
                new TouristBuilding
                {
                    Name = "Pleven",
                    TouristBuildingType = data
                    .TouristBuildingTypes
                    .Where(tbt => tbt.Name == "Hut")
                    .First(),
                    Description = "Pleven hut is located in the Middle Stara Planina, at the northern foot of Botev peak, in the area of Bazov Dyal, above Vidima quarter (town of Apriltsi).",
                    PhoneNumber = "0988 777701",
                    TouristAssociation = data
                    .TouristAssociations
                    .Where(ta => ta.Name == "Kailashka Dolina - Pleven")
                    .First(),
                    Altitude = 1504.0,
                    Coordinate = new Coordinate
                    {
                        LatitudeValue = "42.74960",
                        LongitudeValue = "24.89571"
                    },
                    Capacity = 180,
                    MountainId = staraPlanina.Id,
                    Mountain = staraPlanina
                },
                new TouristBuilding
                {
                    Name = "Kozya Stena",
                    TouristBuildingType = data
                    .TouristBuildingTypes
                    .Where(tbt => tbt.Name == "Hut")
                    .First(),
                    Description = "Building with a capacity of 100 beds in two apartments and rooms with 2-8 beds, floor bathrooms and toilets, own power supply, heating with solid fuel stoves, tourist dining room and kitchen, buffet, pavilion, hall with audio and video equipment.",
                    PhoneNumber = "0885 994 129",
                    TouristAssociation = data
                    .TouristAssociations
                    .Where(ta => ta.Name == "Academic - Ruse")
                    .First(),
                    Altitude = 1536.0,
                    Coordinate = new Coordinate
                    {
                        LatitudeValue = "42.785073",
                        LongitudeValue = "24.529065"
                    },
                    Capacity = 100,
                    MountainId = staraPlanina.Id,
                    Mountain = staraPlanina
                },
                new TouristBuilding
                {
                    Name = "Eho",
                    TouristBuildingType = data
                    .TouristBuildingTypes
                    .Where(tbt => tbt.Name == "Hut")
                    .First(),
                    Description = "Building with a capacity of 40 beds, in rooms with 3-8 beds and 1 room with pomegranates, with private and floor bathrooms and toilets, sinks in some rooms, separate power supply, local heating, tourist dining room and kitchen, buffet, living room hall in traditional style with audio and video equipment, orienteering range.",
                    PhoneNumber = "0888 986 861",
                    TouristAssociation = data
                    .TouristAssociations
                    .Where(ta => ta.Name == "Academic - Ruse")
                    .First(),
                    Altitude = 1645.0,
                    Coordinate = new Coordinate
                    {
                        LatitudeValue = "42.77500",
                        LongitudeValue = "24.48128"
                    },
                    Capacity = 40,
                    MountainId = staraPlanina.Id,
                    Mountain = staraPlanina
                }
            });

            await data.SaveChangesAsync();
        }

        private static async Task SeedTouristAssociation(IServiceProvider services)
        {
            var data = services.GetRequiredService<MountainGuideDbContext>();

            if (await data.TouristAssociations.AnyAsync())
            {
                return;
            }

            await data.TouristAssociations.AddRangeAsync(new[]
            {
                new TouristAssociation
                {
                    Name = "Kailashka Dolina - Pleven",
                    Description = @"Tourist Association ""Kailashka Dolina"" - Pleven was founded in May 1901. The initiator of the founding of the tourist association in Pleven was Eng. Damyan Valchanov Ivanov, who together with Iv. Genchev, As. Minchev, Yanaki Karalski, Iliya Tonkov, Nick. Bardarov, Kancho Moshev, Angel Danov, Iv. Burdzhev, Marin Minchev, St. Panayotov and Roman Dachev established TD ""Kailashka Dolina"".",
                    LogoUrl = "http://www.td-kdolina.free.bg/images/logo.jpg",
                    WebSiteUrl = "https://www.facebook.com/TDKailashkaDolinaPleven/"
                },
                new TouristAssociation
                {
                    Name = "Academic - Ruse",
                    Description = @"Sports tourist and nature protection association ""Academic"" - Ruse",
                    LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/BTS_Logo.svg/514px-BTS_Logo.svg.png",
                    WebSiteUrl = "https://www.facebook.com/academicruse"
                }
            });

            await data.SaveChangesAsync();
        }

        private static async Task SeedPeak(IServiceProvider services)
        {
            var data = services.GetRequiredService<MountainGuideDbContext>();

            if (await data.Peaks.AnyAsync())
            {
                return;
            }

            Mountain staraPlanina = data
                .Mountains
                .Where(m => m.Name == "Stara planina")
                .First();
            Mountain rila = data
                .Mountains
                .Where(m => m.Name == "Rila")
                .First();

            await data.Peaks.AddRangeAsync(new[]
            {
                new Peak
                {
                    Name = "Musala",
                    Altitude = 2.925,
                    MountainId = rila.Id,
                    Mountain = rila,
                    Coordinate = new Coordinate
                    {
                        LatitudeValue = "42.1792",
                        LongitudeValue = "23.5852"
                    }
                },
                new Peak
                {
                    Name = "Malyovitsa",
                    Altitude = 2.729,
                    MountainId = rila.Id,
                    Mountain = rila,
                    Coordinate = new Coordinate
                    {
                        LatitudeValue = "42.1667",
                        LongitudeValue = "23.3667"
                    }
                },
                new Peak
                {
                    Name = "Botev",
                    Altitude = 2.376,
                    Mountain = staraPlanina,
                    MountainId = staraPlanina.Id,
                    Coordinate = new Coordinate
                    {
                        LatitudeValue = "42.7175",
                        LongitudeValue = "24.9167"
                    }
                },
                new Peak
                {
                    Name = "Vezhen",
                    Altitude = 2.198,
                    Mountain = staraPlanina,
                    MountainId = staraPlanina.Id,
                    Coordinate = new Coordinate
                    {
                        LatitudeValue = "42.7500",
                        LongitudeValue = "24.4000"
                    }
                }
            });

            await data.SaveChangesAsync();
        }

        private static async Task SeedMountain(IServiceProvider services)
        {
            var data = services.GetRequiredService<MountainGuideDbContext>();

            if (await data.Mountains.AnyAsync())
            {
                return;
            }

            await data.Mountains.AddRangeAsync(new[]
            {
                new Mountain {Name = "Stara planina",
                    Description = "The Balkan mountain range (known locally also as Stara planina) is a mountain range in the eastern part of the Balkan Peninsula in Southeastern Europe. The range is conventionally taken to begin at the peak of Vrashka Chuka on the border between Bulgaria and Serbia. It then runs for about 560 kilometres (350 mi), first in a south-easterly direction along the border, then eastward across Bulgaria, forming a natural barrier between the northern and southern halves of the country, before finally reaching the Black Sea at Cape Emine. The mountains reach their highest point with Botev Peak at 2,376 metres (7,795 ft)."},
                new Mountain {Name = "Rila",
                    Description = "Rila is the highest mountain range of Bulgaria, the Balkan Peninsula and Southeast Europe. It is situated in southwestern Bulgaria and forms part of the Rila–Rhodope Massif. The highest summit is Musala at an altitude of 2,925 m which makes Rila the sixth highest mountain range in Europe."}
            });

            await data.SaveChangesAsync();
        }

        private static async Task SeedTouristBuildingType(IServiceProvider services)
        {            
            var data = services.GetRequiredService<MountainGuideDbContext>();

            if (await data.TouristBuildingTypes.AnyAsync())
            {
                return;
            }

            await data.TouristBuildingTypes.AddRangeAsync(new[]
            {
                new TouristBuildingType { Name = "Hut" },
                new TouristBuildingType { Name = "Shelter" },
                new TouristBuildingType { Name = "Тourist dormitory" },
                new TouristBuildingType { Name = "Hotel" },
            });

            await data.SaveChangesAsync();
        }

        private static async Task MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<MountainGuideDbContext>();

            await data.Database.MigrateAsync();
        }
    }
}
