namespace MollisHome.Services.Data.Colors
{
    using AutoMapper;

    using MollisHome.Data;
    using MollisHome.Data.Models;

    using MollisHome.Services.Data.Base;
    using MollisHome.Services.DTOs.Colors;

    using System.Linq;
    using System.Threading.Tasks;

    public class ColorsService : BaseService<Color, ColorDTO>, IColorsService
    {
        //------------- CONSTRUCTORS --------------
        public ColorsService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {

        }

        //--------------- METHODS -----------------
        public override async Task<string> CreateAsync(ColorDTO item)
        {
            string msg = await base.CreateAsync(item);
            if (msg.EndsWith("✔️"))
            {
                return $"Цвета '{item.Name}' със стойност - ({item.HexValue}) създаден успешно. ✔️";
            }
            return msg;
        }

        //---- GET BY ----
        public ColorDTO GetByName(string colorName)
        {
            return this.mapper.Map<Color, ColorDTO>(this.dbSet.FirstOrDefault(x => x.Name == colorName));
        }
    }
}
