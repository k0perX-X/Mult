uses graphABC;

const
  dt = 1; //не надо
  kB = 1; 
  kM = 40;
  radiusB = 50;
  radiusM = 10;
  massaB = 20;
  massaM = 1;
  wh = 600;
  wl = 600;
  razbros = 10;

var
  t: real;
  i, j: integer;
  sa, ca, px, py, vx, vy: real;
  flag: boolean;
  molek: array[0..100] of record
    r, m: longint;
    x, y, ix, iy: real;
  end;
  rast: array[0..100, 0..100] of real;

begin
  setwindowsize(wl, wh);
  for i := 0 to kB - 1 do
    with molek[i] do
    begin
      r := radiusB;
      m := massaB;
      j := random(razbros) + 1;
      ix := 0;
      iy := 0;
      repeat
        flag := true;
        x := random(wl - 2 * r) + r;
        y := random(wh - 2 * r) + r;
        for j := 0 to i - 1
        do 
        begin
          rast[j, i] := sqrt(sqr(molek[i].x - molek[j].x) + sqr(molek[i].y - molek[j].y));
          if (rast[j, i] <= molek[i].r + molek[j].r)
            then flag := false;
        end;
      until flag;
    end;
  for i := kB to kM + kB //opisanie molekul
    do 
    with molek[i] do
    begin
      r := radiusM; 
      m := massaM;
      j := random(razbros) + 1;
      ix := j * cos(random(360) / 360 * pi) * m;
      iy := j * sin(random(360) / 360 * pi) * m;
      repeat
        flag := true;
        x := random(wl - 2 * r) + r;
        y := random(wh - 2 * r) + r;
        for j := 0 to i - 1
        do 
        begin
          rast[j, i] := sqrt(sqr(molek[i].x - molek[j].x) + sqr(molek[i].y - molek[j].y));
          if (rast[j, i] <= molek[i].r + molek[j].r)
            then flag := false;
        end;
      until flag;
    end;
  t := 0;
  while true
  do 
  begin
    lockdrawing;
    clearwindow;
    setpencolor(clblue);
    SetBrushColor(clblue);
    for i := kB to kM + kB //dvijenie
      do 
      with molek[i] do
      begin
        if ((x <= r) and (ix < 0)) or ((x >= wl - r) and (ix > 0))
          then ix := -ix;
        x := ix / m / dt + x;
        if ((y >= wh - r) and (iy > 0)) or ((y <= r) and (iy < 0))
          then iy := -iy;
        y := iy / m / dt + y;
        circle(round(x), round(y), r);
      end;
    setpencolor(clred);
    SetBrushColor(clred);
    for i := 0 to kB - 1 do
      with molek[i] do
      begin
        if ((x <= r) and (ix < 0)) or ((x >= wl - r) and (ix > 0))
          then ix := -ix;
        x := ix / m / dt + x;
        if ((y >= wh - r) and (iy > 0)) or ((y <= r) and (iy < 0))
          then iy := -iy;
        y := iy / m / dt + y;
        circle(round(x), round(y), r);
      end;
    for i := 0 to kM + kB //rastoyaniya
      do 
      for j := i + 1 to kM + kB
        do rast[i, j] := sqrt(sqr(molek[i].x - molek[j].x) + sqr(molek[i].y - molek[j].y));
    for i := 0 to kM + kB do //impuls
      for j := i + 1 to kM + kB
        do 
        if (rast[i, j] <= molek[i].r + molek[j].r)
        then begin
          vx := molek[i].ix / molek[i].m - molek[j].ix / molek[j].m;
          vy := molek[i].iy / molek[i].m - molek[j].iy / molek[j].m;
          ca := (molek[j].x - molek[i].x) / rast[i, j];
          sa := (molek[j].y - molek[i].y) / rast[i, j];
          px := 2 * molek[i].m * molek[j].m * (vx * ca + vy * sa) / (molek[i].m + molek[j].m) * ca;
          py := px / ca * sa;
          if sign(px) * sign(ca) > 0 then begin
            molek[i].ix := vx * molek[i].m - px + molek[j].ix / molek[j].m * molek[i].m;
            molek[i].iy := vy * molek[i].m - py + molek[j].iy / molek[j].m * molek[i].m;
            molek[j].ix := px + molek[j].ix;
            molek[j].iy := py + molek[j].iy;
          end;
        end;
    
    sleep(20);
    redraw;
  end;
end.