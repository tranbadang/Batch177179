﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace DatabaseFirstDemo.Models;

public partial class News
{
    public int Id { get; set; }

    public int CategoryId { get; set; }
    [DisplayName("Tiêu đề")]
    public string? Title { get; set; }
    [DisplayName("Mô tả")]
    public string? Description { get; set; }

    public string? SubjectContent { get; set; }
    [DisplayName("Ngày đăng")]
    public DateTime DateUpdate { get; set; }
    [DisplayName("Trạng thái")]
    public bool Status { get; set; }
    [DisplayName("Ảnh đại diện")]
    public string Avatar { get; set; } = null!;

    public int UserId { get; set; }

    public virtual NewsCategory Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;
    /*    [NotMapped]
     [DisplayName("Upload File")]
     public IFormFile ImageFile { get; set; }*/
}
