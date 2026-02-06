# tedesco

music related library focussed around guitar notation.

```text
  E | |---|-----|-----|-----|-----|-----|
  B | |---|-----|-----|-----|-----|-----|
  G | |---|-----|-----|-----|-----|-----|
  D | |---|-----|-----|-----|-----|-----|
  A | |---|-----|-----|-----|-----|-----|
  E | |---|-----|-----|-----|-----|-----|
```

## Prerequisites

- Python 3.9+ installed and on your `PATH`
- `pip` installed 
- (Recommended) `virtualenv` or `python -m venv` for isolation

## Dev Setup

### 1 Clone the rep

```bash
git clone <repo>
cd tedesco
```

### 2 Create and activate a virtual environment

```bash
python -m venv .venv
# Windows
.\.venv\Scripts\activate
# Or mac OS or Linux
source .venv/bin/activate
```

### 3 Upgrade packaging tools

```bash
python -m pip install --upgrade pip setuptools wheel
```

### 4 Install tedesco as a package in editable mode

```bash
python -m pip install -e .
```

### 5 Install dev dependencies

```bash
python -m pip install -r requirements-dev.txt
```

### 6 Set up pre-commit hooks

```bash
pre-commit install
pre-commit run --all-files
```

### 7 Run (tests only) or...

```bash
pytest
```

### 8 Run tox

```bash
tox -e lint
tox -e format
tox -e typecheck
tox -e auto
```
