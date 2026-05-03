# RunAway-AI-Prototype
# 🛸 Run Away — AI & Gameplay Prototype
<img width="1027" height="633" alt="Ekran görüntüsü 2026-05-03 235939" src="https://github.com/user-attachments/assets/d0aea7cf-f091-425a-93a4-f0e3f9120c1f" />
<img width="888" height="579" alt="Ekran görüntüsü 2026-05-04 000158" src="https://github.com/user-attachments/assets/f912c6f4-4883-4d56-a450-8a778c76a928" />
<img width="1115" height="742" alt="Ekran görüntüsü 2026-05-04 000021" src="https://github.com/user-attachments/assets/b88e0df2-df3d-4a68-a454-a0f218f66a52" />

 
> 🇹🇷 Türkçe aşağıda / 🇬🇧 English below
 
---
 
## 🇬🇧 English
 
### What is this?
A technical prototype developed in Unity to showcase core Game AI systems, procedural content generation, and dynamic difficulty scaling. The player controls an alien trying to escape Earth and reach space, while human NPCs try to stop them.
 
### Core Systems
 
**1. FSM-Based Enemy AI**
Enemies use a 3-state Finite State Machine powered by Unity NavMesh:
- `Idle` → Player out of detection range, NPC stands still
- `Chase` → Player detected, NPC moves toward player
- `Attack` → Player within attack range, Game Over triggered
```
[ Idle ] → player enters range → [ Chase ] → player too close → [ Attack ]
              ↑
         player leaves range
```
 
**2. PCG — Procedural Level Generation**
- Enemies and coins are randomly placed on the arena every level
- Arena size shrinks algorithmically as levels progress
- No two playthroughs are identical
**3. Dynamic Difficulty Scaling**
- Enemy speed increases every level
- Arena shrinks progressively
- Coin requirements increase per level
**4. Save / Load System**
- Checkpoint-based progression using `PlayerPrefs`
- Every 5 levels a checkpoint is saved
- On death, player returns to last checkpoint
- Works across sessions (browser-persistent in WebGL)
**5. Level Progression — 52 Levels, 5 Environments**
 
| Levels | Environment | Ground | Sky |
|--------|------------|--------|-----|
| 1-10 | City | Gray | Cloudy |
| 11-20 | Forest | Green | Light blue |
| 21-30 | Mountain | Brown | Blue |
| 31-40 | Sky | White | Orange-pink |
| 41-52 | Space | Black | Dark |
 
### How to Play
- Click anywhere to move (NavMesh pathfinding)
- Collect all coins to advance to the next level
- Avoid enemies — if caught, Game Over
- Press **N** to skip to next level (demo mode)
### Tech Stack
- Unity
- C#
- NavMesh (AI Navigation)
- FSM (Finite State Machine)
- PCG (Procedural Content Generation)
- PlayerPrefs (Save/Load)
- Particle System (VFX)
- AudioSource (SFX)
### Files
```
RunAway-AI-Prototype
 ┣ LevelGenerator.cs   ← PCG + Level system + Save/Load
 ┣ NPC.cs              ← FSM enemy AI
 ┣ Player.cs           ← NavMesh movement
 ┣ Coin.cs             ← Coin collection + VFX
 ┣ SoundManager.cs     ← Audio system
 ┣ LevelData.cs        ← 52 level data
 ┗ README.md
```
 
### Links
- 🎮 **Play on itch.io:** https://7iremkrkmz.itch.io/run-away-ai-gameplay-prototype
- 💼 **LinkedIn:** https://www.linkedin.com/in/irem-nur-korkmaz-dev/
---
 
## 🇹🇷 Türkçe
 
### Bu ne?
Unity'de geliştirilmiş teknik bir prototip. Temel Game AI sistemlerini, prosedürel içerik üretimini ve dinamik zorluk artışını göstermek amacıyla yapılmıştır. Oyuncu, Dünya'ya düşen bir uzaylıyı kontrol eder. Amaç insanlardan kaçıp uzaya ulaşmak.
 
### Temel Sistemler
 
**1. FSM Tabanlı Düşman Yapay Zekası**
Düşmanlar Unity NavMesh ile güçlendirilmiş 3 durumlu FSM kullanır:
- `Idle` → Oyuncu menzil dışında, NPC bekler
- `Chase` → Oyuncu algılandı, NPC kovalar
- `Attack` → Oyuncu çok yakın, Game Over tetiklenir
**2. PCG — Prosedürel Level Üretimi**
- Düşmanlar ve coinler her levelde rastgele yerleşir
- Arena boyutu algoritmik olarak küçülür
- Her oynanış farklıdır
**3. Dinamik Zorluk Artışı**
- Düşman hızı her level artar
- Arena giderek küçülür
- Coin gereksinimleri artar
**4. Save / Load Sistemi**
- `PlayerPrefs` tabanlı checkpoint sistemi
- Her 5 levelda bir checkpoint kaydedilir
- Ölünce son checkpoint'e dönülür
- WebGL'de tarayıcı oturumları arasında çalışır
**5. Level İlerlemesi — 52 Level, 5 Ortam**
 
| Levellar | Ortam | Zemin | Gökyüzü |
|----------|-------|-------|---------|
| 1-10 | Şehir | Gri | Bulutlu |
| 11-20 | Ağaçlık | Yeşil | Açık mavi |
| 21-30 | Dağ | Kahverengi | Mavi |
| 31-40 | Gökyüzü | Beyaz | Turuncu-pembe |
| 41-52 | Uzay | Siyah | Karanlık |
 
### Nasıl Oynanır
- Fareyle tıkla → hareket et (NavMesh pathfinding)
- Tüm coinleri topla → sonraki levele geç
- Düşmanlardan kaç → yakalanırsan Game Over
- **N tuşu** → sonraki levele atla (demo modu)
### Kullanılan Teknolojiler
- Unity
- C#
- NavMesh (AI Navigation)
- FSM (Finite State Machine)
- PCG (Prosedürel İçerik Üretimi)
- PlayerPrefs (Save/Load)
- Particle System (Görsel Efektler)
- AudioSource (Ses Efektleri)
### Dosyalar
```
RunAway-AI-Prototype
 ┣ LevelGenerator.cs   ← PCG + Level sistemi + Save/Load
 ┣ NPC.cs              ← FSM tabanlı düşman AI
 ┣ Player.cs           ← NavMesh hareketi
 ┣ Coin.cs             ← Coin toplama + VFX
 ┣ SoundManager.cs     ← Ses sistemi
 ┣ LevelData.cs        ← 52 level verisi
 ┗ README.md
```
 
### Bağlantılar
- 🎮 **itch.io:** https://7iremkrkmz.itch.io/run-away-ai-gameplay-prototype
- 💼 **LinkedIn:** https://www.linkedin.com/in/irem-nur-korkmaz-dev/
 
