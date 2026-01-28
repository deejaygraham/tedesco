# tedesco
music related things

## Dev setup

* clone repo
* create a virtual environment and activate
  - python -m venv .venv
  - source .venv/bin/activate or .\.venv\Scripts\activate
* upgrade packaging tools
  - pip install --upgrade pip setuptools wheel
* install the package
  - pip install -e .
* install dev dependencies
  - pip install -r requirements-dev.txt
* add pre-commit
  - pip install pre-commit
  - pre-commit install
  - pre-commit run --all-files        
  - tox -e lint
  - tox -e format
  - tox -e typecheck
  - tox -e auto
