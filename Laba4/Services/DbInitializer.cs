using laba_1.DAL.Data;
using laba_1.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba_1.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана 
            context.Database.EnsureCreated();

            //проверка наличия групп обьектов
            if (!context.AjaxGroups.Any())
            {
                context.AjaxGroups.AddRange(
                    new List<AjaxGroup>
                {
                new AjaxGroup{GroupName="Контроллеры"},
                new AjaxGroup{GroupName="Датчики пожарные"},
                new AjaxGroup{GroupName="Датчики охранные"},
                new AjaxGroup{GroupName="Датчики водяные"},
                new AjaxGroup{GroupName="Рэлле"},
                new AjaxGroup{GroupName="Средства оповещения"}

                });
                await context.SaveChangesAsync();
            }

            // проверка наличия объектов
            if (!context.Ajaxes.Any())
            {
                context.Ajaxes.AddRange(new List<Ajax>
                {

                new Ajax
                {
                    DivicesName ="Контроллер",
                    Description ="Wi-fi",
                    detection=2000,
                    AjaxGroupId =1,
                    Image ="AjaxHub-1-456x340-1-456x340.png"
                },
                new Ajax{DivicesName="Охранный датчик",Description="Wi-fi",
                detection=200,AjaxGroupId=3,Image="door_big.png"},
                new Ajax{DivicesName="Рэлле",Description="Wi-fi",
                detection=200,AjaxGroupId=5,Image="ff34-456x340.png"},
                new Ajax{DivicesName="Клавиатура",Description="Wi-fi",
                detection=200,AjaxGroupId=6,Image="keypad_big.png"},
                new Ajax{DivicesName="Пожарный датчик",Description="Wi-fi",
                detection=200,AjaxGroupId=2,Image="MP_Big.png"},
                new Ajax{DivicesName="Сирена",Description="Wi-fi",
                detection=200,AjaxGroupId=2,Image="streetsiren_big-456x340.png"}

                });
                await context.SaveChangesAsync();
            }

                // проверка наличия ролей 
                if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль manager 
                var result = await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей 
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru 
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru 
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }


        }
    }
}
