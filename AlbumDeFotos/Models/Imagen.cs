using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumDeFotos.Models
{
    public class Imagen
    {
        [Key]
        public int ImagenId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Link { get; set; }
        public int AlbunId { get; set; }
        public Album Album { get; set; } // CRIARA UMA CHAVE ESTRANGEIRA PARA ALBUM
    }
}
