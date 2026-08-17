# Web_Test

Small static web project with a simple signup form.

Files:
- `index.html` — form with name and email fields
- `css/styles.css` — styles
- `js/validate.js` — client-side validation

Run instructions

1) Open directly in your browser (no server required):

```plain
Open Web_Test\index.html in your browser (double-click or drag into browser)
```

2) Serve locally with Python 3 (recommended for AJAX or module use):

```bash
cd Web_Test
python -m http.server 8000
# then open http://localhost:8000
```

3) Serve with `npx` (Node) if you have Node.js installed:

```bash
cd Web_Test
npx http-server -p 8000
# or: npx serve -s .
```

That's it — open the page and try submitting the form.
