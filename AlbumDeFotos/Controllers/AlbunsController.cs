﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlbumDeFotos.Models;

namespace AlbumDeFotos.Controllers
{
    public class AlbunsController : Controller
    {
        private readonly Context _context;

        public AlbunsController(Context context)
        {
            _context = context;
        }

        // GET: Albuns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Albuns.ToListAsync());
        }

        // GET: Albuns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albuns
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albuns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albuns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,Destino,FotoTopo,Inicio,Fim")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albuns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albuns.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Albuns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,Destino,FotoTopo,Inicio,Fim")] Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // POST: Albuns/Delete/5
        [HttpPost]
        public async Task<JsonResult> Deletar(int AlbunId)
        {
            var album = await _context.Albuns.FindAsync(AlbunId);
            _context.Albuns.Remove(album);
            await _context.SaveChangesAsync();
            return Json("Album Excluido com sucesso");
        }

        private bool AlbumExists(int id)
        {
            return _context.Albuns.Any(e => e.AlbumId == id);
        }
    }
}
