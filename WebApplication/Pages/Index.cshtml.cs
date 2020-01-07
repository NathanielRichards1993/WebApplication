using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private Server m_server;
        public string m_ServerNumber { get; set; }
        public string m_AlarmNumber { get; set; }

        [BindProperty]
        public string m_InsertText { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger = null)
        {
            _logger = logger;
            m_server = new Server();
            m_ServerNumber = m_server.GetID();
            m_AlarmNumber = m_server.GetAlarm().GetID();
            m_InsertText = "Insert Text Here";
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == true)
            {
                m_server.SetNewServerAndAlarmData(m_InsertText);
                m_ServerNumber = m_server.GetID();
                m_AlarmNumber = m_server.GetAlarm().GetID();
            }
            else
            {
                m_InsertText = "Insert Text Here";
            }
            return Page();
        }
    }
}
