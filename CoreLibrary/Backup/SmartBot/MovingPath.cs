// Decompiled with JetBrains decompiler
// Type: SmartBot.MovingPath
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class MovingPath
{
  private MainPlayerClass _selfInfo;
  public List<MovingPoint> MovingPoints = new List<MovingPoint>();

  public MovingPath(MainPlayerClass selfInfo) => this._selfInfo = selfInfo;

  public int Count => this.MovingPoints.Count;

  public void AddPoint(MovingPoint point)
  {
    if (this.MovingPoints.Count >= 5)
      this.MovingPoints.RemoveAt(0);
    this.MovingPoints.Add(point);
  }

  public MovingPoint LastPoint
  {
    get
    {
      MovingPoint lastPoint = (MovingPoint) null;
      if (this.MovingPoints.Count > 0)
      {
        lastPoint = new MovingPoint();
        lastPoint.X = this.MovingPoints[this.MovingPoints.Count - 1].X;
        lastPoint.Y = this.MovingPoints[this.MovingPoints.Count - 1].Y;
        lastPoint.TimeStamp = this.MovingPoints[this.MovingPoints.Count - 1].TimeStamp;
      }
      return lastPoint;
    }
  }

  public MovingPoint NextPoint(double distance = 19.0, double angle = 0.0)
  {
    MovingPoint movingPoint1 = (MovingPoint) null;
    if (this.MovingPoints.Count >= 2)
    {
      MovingPoint movingPoint2 = this.MovingPoints[this.MovingPoints.Count - 1];
      MovingPoint movingPoint3 = this.MovingPoints[this.MovingPoints.Count - 2];
      movingPoint1 = new MovingPoint();
      if ((double) movingPoint3.X != (double) movingPoint2.X || (double) movingPoint3.Y != (double) movingPoint2.Y)
      {
        double num1 = Math.Atan(((double) movingPoint2.Y - (double) movingPoint3.Y) / ((double) movingPoint2.X - (double) movingPoint3.X)) * 180.0 / Math.PI;
        if ((double) movingPoint3.X > (double) movingPoint2.X && (double) movingPoint3.Y > (double) movingPoint2.Y)
          num1 += 180.0;
        else if ((double) movingPoint3.X > (double) movingPoint2.X && (double) movingPoint3.Y < (double) movingPoint2.Y)
          num1 = 180.0 - num1 * -1.0;
        double num2 = num1 + angle;
        double num3 = Math.Cos(num2 * Math.PI / 180.0) * distance;
        double num4 = Math.Cos((90.0 - num2) * Math.PI / 180.0) * distance;
        movingPoint1.X = movingPoint2.X + (float) num3;
        movingPoint1.Y = movingPoint2.Y + (float) num4;
      }
    }
    return movingPoint1;
  }

  internal void Clear() => this.MovingPoints.Clear();
}
