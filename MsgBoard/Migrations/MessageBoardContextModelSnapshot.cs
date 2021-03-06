// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MsgBoard.Data;

namespace MsgBoard.Migrations
{
    [DbContext(typeof(MessageBoardContext))]
    partial class MessageBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MsgBoard.Models.MessagePost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MessagePost");
                });

            modelBuilder.Entity("MsgBoard.Models.MessageResponse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MessagePostID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MessagePostID");

                    b.ToTable("MessageResponse");
                });

            modelBuilder.Entity("MsgBoard.Models.MessageResponse", b =>
                {
                    b.HasOne("MsgBoard.Models.MessagePost", "MessagePost")
                        .WithMany("MessageResponses")
                        .HasForeignKey("MessagePostID");

                    b.Navigation("MessagePost");
                });

            modelBuilder.Entity("MsgBoard.Models.MessagePost", b =>
                {
                    b.Navigation("MessageResponses");
                });
#pragma warning restore 612, 618
        }
    }
}
