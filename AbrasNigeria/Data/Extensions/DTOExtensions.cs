using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;
using System.Collections.Generic;
using System.Linq;

namespace AbrasNigeria.Data.Extensions
{
    public static class DTOExtensions
    {
        public static MachineDTO ToDTO(this Machine machine)
        {

            return new MachineDTO
            {
                MachineId = machine.MachineId,
                SerialNumber = machine.SerialNumber,
                BrandName = machine.Brand?.Name,
                ModelName = machine.ModelName,
                Sections = machine.Sections.Select(ms => new SectionDTO
                {
                    SectionId = ms.SectionId,
                    SectionName = ms.Section?.SectionName,
                    SectionGroups = machine.SectionGroups
                    .Where(msg => msg.SectionGroup?.Section.SectionId == ms.SectionId)
                    .Select(msg => new SectionGroupDTO
                    {
                        SectionGroupId = msg.SectionGroupId,
                        SectionGroupName = msg.SectionGroup?.SectionGroupName,
                        Products = machine.SectionGroupProducts
                        .Where(p => p.SectionGroupId == msg.SectionGroupId)
                        .Select(sp => new ProductDTO
                        {
                            ProductId = sp.ProductId,
                            PartNumber = sp.Product?.PartNumber,
                            Descriptions = sp.Product.Descriptions.Select(d => new DescriptionDTO
                            {
                                DescriptionName = d.Description?.DescriptionName
                            })
                        })
                    })
                })
            };

        }

        public static IEnumerable<MachineDTO> ToDTO(this IEnumerable<Machine> machines)
        {
            return machines.Select(m => m.ToDTO());
        }

        public static ProductDTO ToDTO(this Product product)
        {
            return new ProductDTO
            {
                ProductId = product.ProductId,
                PartNumber = product.PartNumber,
                Brand = product.Brand?.Name,
                Section = product.Section?.SectionName,

                Descriptions = product.Descriptions.Select(pc => new DescriptionDTO
                {
                    DescriptionName = pc.Description?.DescriptionName
                }),

                Machines = product.MachineSectionGroups
                    .Where(pm => pm.Product.MachineSectionGroups
                    .Contains(product.MachineSectionGroups.Where(pd => pd.ProductId == product.ProductId).FirstOrDefault()))
                    .Select(m => new MachineDTO
                    {
                        MachineId = m.MachineId,
                        ModelName = m.Machine?.ModelName
                    }),

                SectionGroups = product.SectionGroups
                    .Where(psg => psg.Product.SectionGroups
                    .Contains(product.SectionGroups.Where(_psg => _psg.ProductId == product.ProductId).FirstOrDefault()))
                    .Select(sg => new SectionGroupDTO
                    {
                        SectionGroupName = sg.SectionGroup?.SectionGroupName,
                    })
            };
        }

        public static IEnumerable<ProductDTO> ToDTO(this IEnumerable<Product> products)
        {
            return products.Select(p => p.ToDTO());
        }


    }
}
