using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Osis.Model
{
    public class DataOsis
    {
        public int id { get; set; }

        public string nis { get; set; }
        [Required(ErrorMessage = "nama wajib diisi")]
        public string nama { get; set; }
        public string kelas { get; set; }
        public string jabatan { get; set; }
    }
}
