using System;
using System.Collections.Generic;

namespace bustop_RestAPI.Models;

/// <summary>
/// 버스 정보를 담는 테이블
/// </summary>
public partial class BusTable
{
    public int BusIdx { get; set; }

    public string BusNum { get; set; } = null!;

    public int BusCnt { get; set; }

    public int BusGap { get; set; }

    public int BusNowIn { get; set; }
}
