using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly DatabaseContext _databaseContext; // kjo eshte databasa vetem e lexushme
        public WarehouseController(DatabaseContext databaseContext) //contsurctori ekzekutohet sa therritet klasa
        {
            
            _databaseContext = databaseContext;

        }

        public IActionResult Index() //crudi index
        {
            var warehouses = _databaseContext.Warehouses.ToList(); // ktu marim te gjith warhouset dhe i ruam ne nje variabel
            return View(warehouses); //ketu hapim viewn e index duke derguar  variablem warehouses si parameter
        }
        [HttpGet]
        public IActionResult Create() //metoda e par Create e cila sherben si get
        {
            var warehouseForCreation = new WarehouseForCreationDto(); //krijojme nje objekt me WarehouseForCreationDto e cila sherben si klas ndermjetsuese per te hapur dhe mbajturt vecorite e Warehousit
            return View(warehouseForCreation); //hapim viewn e krijimit duke derguar si parameter warehouseForCreation(me te gjithe vecorite e warehousit)
        }
        [HttpPost]
        public IActionResult Create(WarehouseForCreationDto dto) //metoda e dyte krijim do te sherbeje per te shtuar nje warehouse ne database
        {
            Warehouse.Data.Warehouse warehouse = new Warehouse.Data.Warehouse(); //krijome nje objekt warehouse qe do te mbaje te gjithe vecorite e ardhuara nga view


            //kemi mapimin si psh objekti bosh i warehousit do te mbushet me vecprite e ardhura nga view (WarehouseForCreationDto dto)
            warehouse.Name = dto.Name;
            warehouse.Description = dto.Description;
            warehouse.Location = dto.Location;

            _databaseContext.Add(warehouse);//ne database ne shtojme nje warehose te ri
            _databaseContext.SaveChanges(); //ruajme ndryshimin ne database

            return RedirectToAction("Index"); //hapim view Index

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var warehouse = _databaseContext.Warehouses.Where(x => x.Id == id).FirstOrDefault(); //marim magazinen qe ka ate id  na ka ardhur nga view dhe arsya tjeter qe e marim eshte
                                                                                                 //qe te shikojme vlerat si kan qene psh  si ka qene emri description tjr
            var warehouseForMod = new WarehouseForModificationDto();


            //klasa e re qe perdoret per view eshte warehouse for mod dhe vecorite e ksaj do te jene te = me vecorite e klases ne database
            warehouseForMod.Id = warehouse.Id;
            //psh emri qe do shfaqet ne view eshte e barabarte me emrin e warehausit me id qe na ka ardhur nga view
            warehouseForMod.Name = warehouse.Name;
            warehouseForMod.Description = warehouse.Description;
            warehouseForMod.Location = warehouse.Location;
            return View(warehouseForMod);

        }
        [HttpPost]
        public IActionResult Edit(WarehouseForModificationDto dto)
        {
            // marim warehusin me id qe na ka ardhur nga view pra warehousi qe to do editohet
            var warehouse = _databaseContext.Warehouses.Where(x => x.Id == dto.Id).FirstOrDefault();

            //warehouseforModDto eshte objekti i cili ka te dhenat e warehosit qe kan ardhur nga view pra te dhenat e updatuara
            //pra variable warehouse ka te dhenat e vjetra te warehosit pra te dhenat qe kane qene ne database
            //na ngel per te bere mapimin
            //warhosi.property e  vjeter do barazohet me warehose.property qe na kane ardhur nga view

            warehouse.Name = dto.Name;
            warehouse.Description = dto.Description;
            warehouse.Location = dto.Location;

            //na ngel te updatetojme ne database Warehosin

            _databaseContext.Update(warehouse);
            //na ngel te ruajme ndryshimet ne database
            _databaseContext.SaveChanges();

            //hapi i fudnit eshte returni

            return RedirectToAction("Index"); // sherben qe pas editimit te shkoje tek VIEW Index

        }

      
        public IActionResult Delete(int id)
        {
            var warehouse = _databaseContext.Warehouses.Where(x => x.Id == id).FirstOrDefault(); //marim warehosen me id qe na vjen nga view dhe e kthejm ne nje te vetme
            _databaseContext.Remove(warehouse); //ne kete rrjesht ne fshim nga database warehausin e gjetur
            _databaseContext.SaveChanges(); // ne kete rrjesht ruajm databasen me ndryshimet e bera
            return RedirectToAction("Index"); // sherben qe pas editimit te shkoje tek VIEW Index

        }

    }
}
