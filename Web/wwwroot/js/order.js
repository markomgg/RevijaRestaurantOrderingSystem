document.addEventListener('DOMContentLoaded', async () => {
  const menuDiv = document.getElementById('menu');
  const selectionDiv = document.getElementById('selection');
  const placeBtn = document.getElementById('placeOrder');
  const clearBtn = document.getElementById('clearSelection');
  const message = document.getElementById('message');

  const res = await fetch('/api/menu-items');
  const items = await res.json();

  // Render items as cards with quantity inputs
  items.forEach(i => {
    const card = document.createElement('div');
    card.innerHTML = `
      <div class="menu-title">${i.name}</div>
      <div class="menu-desc">${i.description || ''}</div>
      <div class="menu-meta">
        <div><strong>${i.price} MKD</strong></div>
        <div><input class="qty" type="number" min="0" value="0" data-id="${i.id}"/></div>
      </div>`;
    menuDiv.appendChild(card);
  });

  function refreshSelection() {
    const qtyInputs = document.querySelectorAll('input[data-id]');
    const selected = [];
    qtyInputs.forEach(inp => {
      const q = parseInt(inp.value || '0');
      if (q > 0) selected.push({ id: inp.getAttribute('data-id'), qty: q });
    });
    if (selected.length === 0) {
      selectionDiv.textContent = 'No items selected.';
      return;
    }
    selectionDiv.innerHTML = selected.map(s => `Item ${s.id} × ${s.qty}`).join('<br/>');
  }

  menuDiv.addEventListener('input', refreshSelection);
  clearBtn.addEventListener('click', () => {
    document.querySelectorAll('input[data-id]').forEach(i => i.value = '0');
    refreshSelection();
  });

  placeBtn.addEventListener('click', async () => {
    message.textContent = '';
    const qtyInputs = document.querySelectorAll('input[data-id]');
    const itemsToOrder = [];
    qtyInputs.forEach(inp => {
      const q = parseInt(inp.value || '0');
      if (q > 0) itemsToOrder.push({ menuItemId: parseInt(inp.getAttribute('data-id')), quantity: q });
    });

    if (itemsToOrder.length === 0) { message.textContent = 'Select at least one item.'; return; }

    // Use customer id 1 for demo
    const payload = { customerId: 1, items: itemsToOrder };
    const r = await fetch('/api/orders', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(payload) });
    if (r.ok) {
      message.textContent = 'Order placed.';
      window.location.href = '/orders.html';
    } else {
      message.textContent = 'Failed to place order.';
    }
  });
});
