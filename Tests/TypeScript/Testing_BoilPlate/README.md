# Testing_BoilPlate

Simple registration form boilerplate for testing purposes.

Files
- `index.html` — registration form with username, email and submit button
- `css/styles.css` — basic styles
- `js/validate.js` — simple client-side validation and demo submit handler

Usage
- Open `index.html` in your browser (double-click or use `Open File...`).

Run with a simple static server (recommended):

Install `live-server` globally if you have Node.js:

```bash
npm install -g live-server
```

Then run from this folder:

```bash
live-server
```

Or use `serve`:

```bash
npm install -g serve
serve .
```

Notes
- The form uses client-side validation only for demo/testing.
- To integrate into automated tests, point your test runner at `index.html` or serve the folder and use a browser automation tool.
