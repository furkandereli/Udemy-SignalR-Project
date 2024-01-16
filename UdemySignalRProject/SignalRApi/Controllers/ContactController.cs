using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Mail = createContactDto.Mail,
                Phone = createContactDto.Phone,
                FooterTitle = createContactDto.FooterTitle,
                OpenDays = createContactDto.OpenDays,
                OpenDaysDescription = createContactDto.OpenDaysDescription,
                OpenHours = createContactDto.OpenHours
            });

            return Ok("İletişim bilgisi eklendi !");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("İletişim bilgisi silindi !");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateCategoryDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactId = updateCategoryDto.ContactId,
                FooterDescription = updateCategoryDto.FooterDescription,
                Location = updateCategoryDto.Location,
                Mail = updateCategoryDto.Mail,
                Phone = updateCategoryDto.Phone,
				FooterTitle = updateCategoryDto.FooterTitle,
				OpenDays = updateCategoryDto.OpenDays,
				OpenDaysDescription = updateCategoryDto.OpenDaysDescription,
				OpenHours = updateCategoryDto.OpenHours
			});

            return Ok("İletişim bilgisi güncellendi !");
        }
    }
}
