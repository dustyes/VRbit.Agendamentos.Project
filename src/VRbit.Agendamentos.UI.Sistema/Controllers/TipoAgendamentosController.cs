using System;
using System.Net;
using System.Web.Mvc;
using VRbit.Agendamentos.Application.Interfaces;
using VRbit.Agendamentos.Application.Services;
using VRbit.Agendamentos.Application.ViewModels;

namespace VRbit.Agendamentos.UI.Sistema
{
    [RoutePrefix("tipoagendamentos")]
    public class TiposAgendamentoController : Controller
    {
        private readonly ITipoAgendamentoAppService _tipoAgendamentoAppService;

        public TiposAgendamentoController()
        {
            _tipoAgendamentoAppService = new TipoAgendamentoAppService();
        }

        [Route("listar-tipoagendamentos")]
        public ActionResult Index()
        {
            return View(_tipoAgendamentoAppService.ObterTodos());
        }

        [Route("detalhe-tipoagendamento")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAgendamentoViewModel tipoAgendamentoViewModel = _tipoAgendamentoAppService.SelecionarPorId(id.Value);
            if (tipoAgendamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(tipoAgendamentoViewModel);
        }

        [Route("novo-tipoagendamento")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("novo-tipoagendamento")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoAgendamentoId,Descricao,Interno")] TipoAgendamentoViewModel tipoAgendamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                _tipoAgendamentoAppService.Adicionar(tipoAgendamentoViewModel);
                return RedirectToAction("Index");
            }

            return View(tipoAgendamentoViewModel);
        }

        [Route("editar-tipoagendamento")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAgendamentoViewModel tipoAgendamentoViewModel = _tipoAgendamentoAppService.SelecionarPorId(id.Value);
            if (tipoAgendamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(tipoAgendamentoViewModel);
        }

        [HttpPost]
        [Route("editar-tipoagendamento")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoAgendamentoId,Descricao,Interno")] TipoAgendamentoViewModel tipoAgendamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                _tipoAgendamentoAppService.Atualizar(tipoAgendamentoViewModel);
                return RedirectToAction("Index");
            }
            return View(tipoAgendamentoViewModel);
        }

        [Route("{id:guid}/excluir-tipoagendamento")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAgendamentoViewModel tipoAgendamentoViewModel = _tipoAgendamentoAppService.SelecionarPorId(id.Value);
            if (tipoAgendamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(tipoAgendamentoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("{id:guid}/excluir-tipoagendamento")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _tipoAgendamentoAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tipoAgendamentoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
