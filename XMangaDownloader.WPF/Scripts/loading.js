const overlay = document.createElement("div");

overlay.style.height = "100vh";
overlay.style.width = "100vw";
overlay.style.background = "black";
overlay.style.opacity = "0.5";
overlay.style.position = "fixed";
overlay.style.top = "0";
overlay.style.left = "0";
overlay.style.zIndex = "9999";

document.body.style.overflow = "hidden";
document.body.appendChild(overlay);


