﻿using System;
using System.Collections.Generic;

namespace NotePad.MVVM.Models;

public partial class Note
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Text { get; set; }
}
