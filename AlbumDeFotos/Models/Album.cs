using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumDeFotos.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        [StringLength(50 , ErrorMessage = "Digite Menos Caracteres")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string FotoTopo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}" , ApplyFormatInEditMode =true )]
        public DateTime Inicio { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fim { get; set; }
        public ICollection<Imagen> Imagen { get; set; }
    }
}   
