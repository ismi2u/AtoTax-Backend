using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtoTax.Domain.Entities
{
    public class MultimediaType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Media { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [Required]
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }


        public string? GetMultimedia()
        {
            var NameParts = new List<string>();

            NameParts.Add(Media ?? "");
            NameParts.Add(Description ?? "");

            return String.Join(":", NameParts.Where(s => !String.IsNullOrEmpty(s)));

        }
    }
}
