using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VRbit.Agendamentos.Application.Interfaces;
using VRbit.Agendamentos.Application.Services;
using VRbit.Agendamentos.Application.ViewModels;
using VRbit.Agendamentos.CrossCutting.MvcFilters;
using VRbit.Agendamentos.UI.Sistema.Models;

namespace VRbit.Agendamentos.UI.Sistema.Controllers
{
    //Permissoes Modulo Cliente > CL, CI, CE, CD, CX
    [Authorize]
    [RoutePrefix("clientes")]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();
        }

        // GET: Clientes
        [ClaimsAuthorize("ModuloCliente", "CL")]
        [Route("listar-clientes")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterTodos());
        }

        // GET: Clientes/Details/5
        [ClaimsAuthorize("ModuloCliente", "CD")]
        [Route("{id:guid}/detalhe-cliente")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        [Route("novo-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CI")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [Route("novo-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CI")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        // GET: Clientes/Edit/5
        [Route("{id:guid}/editar-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CE")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [Route("{id:guid}/editar-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CE")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CX")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [Route("{id:guid}/excluir-cliente")]
        [ClaimsAuthorize("ModuloCliente", "CX")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
