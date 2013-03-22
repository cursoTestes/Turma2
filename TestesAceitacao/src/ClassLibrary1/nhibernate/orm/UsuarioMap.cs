using FluentNHibernate.Mapping;
using SistemaVendas.Model;

namespace SistemaVendas.Negocio
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.usuario_id).GeneratedBy.Identity();
            Map(x => x.login).CustomSqlType("varchar(50)");
            Map(x => x.senha).CustomSqlType("varchar(50)");
        }
    }


}