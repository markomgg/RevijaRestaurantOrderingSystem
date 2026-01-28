document.addEventListener('DOMContentLoaded', () => {
  const btn = document.getElementById('getWeather');
  const cityInput = document.getElementById('city');
  const output = document.getElementById('output');

  btn.addEventListener('click', async () => {
    output.textContent = 'Loading...';
    const city = cityInput.value || 'Skopje';
    try {
      const res = await fetch(`/api/weather/${encodeURIComponent(city)}`);
      if (!res.ok) { output.textContent = 'Failed to fetch weather.'; return; }
      const data = await res.json();
      output.textContent = JSON.stringify(data, null, 2);
    } catch (err) { output.textContent = 'Network error.'; }
  });
});
