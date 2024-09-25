using BusinessObject.DTOs.EssayTaskDTOs;
using BusinessObject.DTOs.WorkbookCategoryDTOs;
using BusinessObject.DTOs.WorkbookDTOs;
using BusinessObject.Models;
using ExceptionHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EssayTaskProvidingController : ControllerBase
    {
        private readonly IEssayTaskService _essayTaskService;
        private readonly IWorkbookService _workbookService;
        private readonly IWorkbookCategoryService _workbookCategoryService;

        public EssayTaskProvidingController(IEssayTaskService essayTaskService, IWorkbookService workbookService, IWorkbookCategoryService workbookCategoryService)
        {
            _essayTaskService = essayTaskService;
            _workbookService = workbookService;
            _workbookCategoryService = workbookCategoryService;
        }

        [HttpGet("Workbook")]
        public async Task<ActionResult<IEnumerable<Workbook>>> GetWorkbooks(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 10,
            [FromQuery] string direction = "asc",
            [FromQuery] string sortBy = "ID"
            )
        {
            try
            {
                var Workbooks = await _workbookService.GetAllWorkbooksAsync(offset, limit, direction, sortBy);
                return new JsonResult(new APIReturn()
                {
                    code = 200,
                    message = "Success",
                    data = Workbooks.Cast<object>().ToList()
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new CustomException(HttpStatusCode.NotFound, "An unexpected error occurred",
                        "GetWorkbooks - EssayTaskProviding_API : Workbooks could not be retrieved from the repository",
                        null));
            }

        }

        [HttpGet("Workbook/{id}")]
        public async Task<ActionResult> GetWorkbookById(int id)
        {
            try
            {
                var profile = await _workbookService.GetWorkbookByIdAsync(id);

                if (profile == null)
                {
                    return NotFound(new
                    {
                        code = 404,
                        msg = "Workbook not found",
                    });
                }

                return Ok(new
                {
                    code = 200,
                    msg = "Success",
                    data = profile
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("Workbook")]
        public async Task<ActionResult> UpdateWorkbook(UpdateWorkbookRequestDTO request)
        {
            try
            {
                var update = await _workbookService.UpdateWorkbookAsync(request);

                if (!update)
                {
                    return BadRequest(new
                    {
                        code = 400,
                        msg = "Workbook update failed."
                    });
                }

                return Ok(new
                {
                    code = 200,
                    msg = "Workbook updated successfully",
                    data = update
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("Workbook/{id}")]
        public async Task<ActionResult> DeleteWorkbook(int id)
        {
            try
            {
                var delete = await _workbookService.DeleteWorkbookAsync(id);

                if (!delete)
                {
                    return NotFound(new
                    {
                        code = 404,
                        msg = "Workbook not found",
                    });  
                }
                return Ok(new
                {
                    code = 200,
                    msg = "Workbook deleted successfully",
                    data = delete
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpPost("Workbook")]
        public async Task<ActionResult> AddWorkbook(AddWorkbookRequestDTO request)
        {
            try
            {
                var add = await _workbookService.AddWorkbookAsync(request);

                if (add == null)
                {
                    return BadRequest(new
                    {
                        code = 400,
                        msg = "Workbook added failed."
                    });
                }

                return Ok(new
                {
                    code = 200,
                    msg = "Workbook added successfully",
                    data = add
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("WorkbookCategory")]
        public async Task<ActionResult<IEnumerable<WorkbookCategory>>> GetWorkbookCategories(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 10,
            [FromQuery] string direction = "asc",
            [FromQuery] string sortBy = "ID"
            )
        {
            try
            {
                var Workbooks = await _workbookCategoryService.GetAllWorkbookCategorysAsync(offset, limit, direction, sortBy);
                return new JsonResult(new APIReturn()
                {
                    code = 200,
                    message = "Success",
                    data = Workbooks.Cast<object>().ToList()
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new CustomException(HttpStatusCode.NotFound, "An unexpected error occurred",
                        "GetWorkbooks - EssayTaskProviding_API : Workbooks could not be retrieved from the repository",
                        null));
            }

        }

        [HttpGet("WorkbookCategory/{id}")]
        public async Task<ActionResult> GetWorkbookCategoryById(int id)
        {
            try
            {
                var profile = await _workbookCategoryService.GetWorkbookCategoryByIdAsync(id);

                if (profile == null)
                {
                    return NotFound(new
                    {
                        code = 404,
                        msg = "Workbook Category not found",
                    });
                }

                return Ok(new
                {
                    code = 200,
                    msg = "Success",
                    data = profile
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("WorkbookCategory")]
        public async Task<ActionResult> UpdateWorkbookCategory(UpdateWorkbookCategoryRequestDTO request)
        {
            try
            {
                var update = await _workbookCategoryService.UpdateWorkbookCategoryAsync(request);

                if (!update)
                {
                    return BadRequest(new
                    {
                        code = 400,
                        msg = "Workbook Category update failed."
                    });
                }

                return Ok(new
                {
                    code = 200,
                    msg = "Workbook Category updated successfully",
                    data = update
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("WorkbookCategory/{id}")]
        public async Task<ActionResult> DeleteWorkbookCategory(int id)
        {
            try
            {
                var delete = await _workbookCategoryService.DeleteWorkbookCategoryAsync(id);

                if (!delete)
                {
                    return NotFound(new
                    {
                        code = 404,
                        msg = "Workbook Category not found",
                    });
                }
                return Ok(new
                {
                    code = 200,
                    msg = "Workbook Category deleted successfully",
                    data = delete
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpPost("WorkbookCategory")]
        public async Task<ActionResult> AddWorkbookCategory(AddWorkbookCategoryRequestDTO request)
        {
            try
            {
                var add = await _workbookCategoryService.AddWorkbookCategoryAsync(request);

                if (add == null)
                {
                    return BadRequest(new
                    {
                        code = 400,
                        msg = "Workbook Category added failed."
                    });
                }

                return Ok(new
                {
                    code = 200,
                    msg = "Workbook Category added successfully",
                    data = add
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("EssayTask")]
        public async Task<ActionResult<IEnumerable<EssayTask>>> GetEssayTasks(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 10,
            [FromQuery] string direction = "asc",
            [FromQuery] string sortBy = "ID"
            )
        {
            try
            {
                var Workbooks = await _essayTaskService.GetAllEssayTasksAsync(offset, limit, direction, sortBy);
                return new JsonResult(new APIReturn()
                {
                    code = 200,
                    message = "Success",
                    data = Workbooks.Cast<object>().ToList()
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new CustomException(HttpStatusCode.NotFound, "An unexpected error occurred",
                        "GetWorkbooks - EssayTaskProviding_API : Workbooks could not be retrieved from the repository",
                        null));
            }

        }

        [HttpGet("EssayTask/{id}")]
        public async Task<ActionResult> GetEssayTaskById(int id)
        {
            try
            {
                var profile = await _essayTaskService.GetEssayTaskByIdAsync(id);

                if (profile == null)
                {
                    return NotFound(new
                    {
                        code = 404,
                        msg = "Essay Task not found",
                    });
                }

                return Ok(new
                {
                    code = 200,
                    msg = "Success",
                    data = profile
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("EssayTask")]
        public async Task<ActionResult> UpdateEssayTask(UpdateEssayTaskRequestDTO request)
        {
            try
            {
                var update = await _essayTaskService.UpdateEssayTaskAsync(request);

                if (!update)
                {
                    return BadRequest(new
                    {
                        code = 400,
                        msg = "Essay Task update failed."
                    });
                }

                return Ok(new
                {
                    code = 200,
                    msg = "Essay Task updated successfully",
                    data = update
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("EssayTask/{id}")]
        public async Task<ActionResult> DeleteEssayTask(int id)
        {
            try
            {
                var delete = await _workbookCategoryService.DeleteWorkbookCategoryAsync(id);

                if (!delete)
                {
                    return NotFound(new
                    {
                        code = 404,
                        msg = "Essay Task not found",
                    });
                }
                return Ok(new
                {
                    code = 200,
                    msg = "Essay Task deleted successfully",
                    data = delete
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

        [HttpPost("EssayTask")]
        public async Task<ActionResult> AddEssayTask(AddEssayTaskRequestDTO request)
        {
            try
            {
                var add = await _essayTaskService.AddEssayTaskAsync(request);

                if (add == null)
                {
                    return BadRequest(new
                    {
                        code = 400,
                        msg = "Essay Task added failed."
                    });
                }

                return Ok(new
                {
                    code = 200,
                    msg = "Essay Task added successfully",
                    data = add
                });
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.Status, new
                {
                    code = (int)ex.Status,
                    msg = ex.Message,
                    error = ex.Error,
                    data = ex.Data
                });
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                return StatusCode(500, new
                {
                    code = 500,
                    msg = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }
    }
}
