﻿// <auto-generated />
using System;
using Ci.Calcados.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ci.Calcados.API.Migrations
{
    [DbContext(typeof(ProdutoContext))]
    [Migration("20230112005627_alterando_tabela_cores")]
    partial class alterando_tabela_cores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.HasSequence<int>("MinhaSequencia")
                .StartsAt(1000L);

            modelBuilder.Entity("Ci.Calcados.API.Models.Cor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("removido")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("cores");
                });

            modelBuilder.Entity("Ci.Calcados.API.Models.ImagemProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("removido")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("imagens_produtos");
                });

            modelBuilder.Entity("Ci.Calcados.API.Models.Marca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("removido")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("marcas");
                });

            modelBuilder.Entity("Ci.Calcados.API.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR MinhaSequencia");

                    b.Property<Guid>("CorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("MarcaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoDesconto")
                        .HasColumnType("int");

                    b.Property<Guid>("TipoProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorDesconto")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ValorVenda")
                        .HasColumnType("decimal(5,2)");

                    b.Property<bool>("removido")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CorId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("Ci.Calcados.API.Models.TipoProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("removido")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("tipo_produto");
                });

            modelBuilder.Entity("Ci.Calcados.API.Models.ImagemProduto", b =>
                {
                    b.HasOne("Ci.Calcados.API.Models.Produto", "Produto")
                        .WithMany("Imagens")
                        .HasForeignKey("ProdutoId")
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Ci.Calcados.API.Models.Produto", b =>
                {
                    b.HasOne("Ci.Calcados.API.Models.Cor", "Cor")
                        .WithMany("Produtos")
                        .HasForeignKey("CorId")
                        .IsRequired();

                    b.HasOne("Ci.Calcados.API.Models.Marca", "Marca")
                        .WithMany("Produtos")
                        .HasForeignKey("MarcaId")
                        .IsRequired();

                    b.HasOne("Ci.Calcados.API.Models.TipoProduto", "TipoProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("TipoProdutoId")
                        .IsRequired();

                    b.Navigation("Cor");

                    b.Navigation("Marca");

                    b.Navigation("TipoProduto");
                });

            modelBuilder.Entity("Ci.Calcados.API.Models.Cor", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Ci.Calcados.API.Models.Marca", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Ci.Calcados.API.Models.Produto", b =>
                {
                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("Ci.Calcados.API.Models.TipoProduto", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
