using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Pedidos_SmaXtec.Models;
using Microsoft.AspNet.Identity;

namespace Sistema_Pedidos_SmaXtec.Controllers
{
    public class PedidoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pedido
        public ActionResult Index()
        {
            var pedidoes = db.Pedidoes.Include(p => p.Cliente);
            return View(pedidoes.ToList());
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);

            var user1 = db.Users.Find(pedido.UsuarioId);

            pedido.NomeVendedor = user1.Email;
            
            var client = new Cliente();

            client = db.Clientes.Find(pedido.ClienteID);

            pedido.ClienteNome = client.Nome;


            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome");
            return View();
        }

        // POST: Pedido/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,ClienteID,QuantidadeBase,QuantRepetidor,QuantSensorClimatico,QuantAplicador,QuantSensor,QuantSensorPrimium,DataPedido,ProdutoId")] Pedido pedido)
        {
            pedido.UsuarioId = User.Identity.GetUserId();
            pedido.NomeVendedor = User.Identity.GetUserName();

            var cli = db.Clientes.Find(pedido.ClienteID);

            pedido.ClienteNome = cli.Nome;

            pedido.DataPedido = DateTime.Now;

            decimal valoresItems = 0;

            var listaPeProdutos = db.Produtoes.ToList();

            var produto = new Produto();

            foreach (var item in listaPeProdutos)
            {
                if (item.NomeProduto == "Base")
                {
                    valoresItems += item.Preco * pedido.QuantidadeBase;
                }
                else if (item.NomeProduto == "Repetidor")
                {
                    valoresItems += item.Preco * pedido.QuantRepetidor;
                }
                else if (item.NomeProduto == "Sensor Climatico")
                {
                    valoresItems += item.Preco * pedido.QuantSensorClimatico;
                }
                else if (item.NomeProduto == "Aplicador")
                {
                    valoresItems += item.Preco * pedido.QuantAplicador;
                }
                else if (item.NomeProduto == "Sensor")
                {
                    valoresItems += item.Preco * pedido.QuantSensor;
                }
                else if (item.NomeProduto == "Sensor Premium")
                {
                    valoresItems += item.Preco * pedido.QuantSensorPrimium;
                }


            }

            pedido.ValorTotal = valoresItems;



            if (ModelState.IsValid)
            {
                db.Pedidoes.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome", pedido.ClienteID);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);


            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome", pedido.ClienteID);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,ClienteID,QuantidadeBase,QuantRepetidor,QuantSensorClimatico,QuantAplicador,QuantSensor,QuantSensorPrimium,DataPedido,ProdutoId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.UsuarioId = User.Identity.GetUserId();
                pedido.NomeVendedor = User.Identity.GetUserName();

                var cli = db.Clientes.Find(pedido.ClienteID);

                pedido.ClienteNome = cli.Nome;

                decimal valoresItems = 0;

                var listaPeProdutos = db.Produtoes.ToList();

                var produto = new Produto();

                foreach (var item in listaPeProdutos)
                {
                    if (item.NomeProduto == "Base")
                    {
                        valoresItems += item.Preco * pedido.QuantidadeBase;
                    }
                    else if (item.NomeProduto == "Repetidor")
                    {
                        valoresItems += item.Preco * pedido.QuantRepetidor;
                    }
                    else if (item.NomeProduto == "Sensor Climatico")
                    {
                        valoresItems += item.Preco * pedido.QuantSensorClimatico;
                    }
                    else if (item.NomeProduto == "Aplicador")
                    {
                        valoresItems += item.Preco * pedido.QuantAplicador;
                    }
                    else if (item.NomeProduto == "Sensor")
                    {
                        valoresItems += item.Preco * pedido.QuantSensor;
                    }
                    else if (item.NomeProduto == "Sensor Premium")
                    {
                        valoresItems += item.Preco * pedido.QuantSensorPrimium;
                    }


                }

                pedido.ValorTotal = valoresItems;

                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome", pedido.ClienteID);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            db.Pedidoes.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
