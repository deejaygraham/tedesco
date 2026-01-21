# Rules for Tedesco Project

## Code Style
- Use Python 3.x syntax and features
- Follow PEP 8 style guidelines
- Use descriptive variable and function names
- Include docstrings for all classes and public methods
- Use type hints where appropriate (optional but encouraged)
- Maximum line length: 100 characters

## Documentation
- All classes must have docstrings describing their purpose
- All public methods must have docstrings with:
  - Description of what the method does
  - Args: parameter descriptions with types
  - Returns: return value description (if applicable)
- Use triple-quoted strings for docstrings

## Testing
- Use Python's `unittest` framework
- Test files should be named `*_test.py` in the `tests/` directory
- Test classes should be named `Test<ClassName>` and inherit from `unittest.TestCase`
- Each test method should start with `test_` prefix
- Include docstrings for test methods describing what they test
- Test both positive cases and edge cases (boundary conditions, error cases)
- Use descriptive test method names that explain what is the expected outcome or state
- Test names like "test_init", "test_set_foo" are bad, "test_a_new_foo_is_empty" is better
- Run all tests after each change to make sure we aren't changing too many things at once or breaking something with a change
- If a test or tests break due to a code change, revert the code, do not delete the test

## Code Organization
- Keep classes focused and single-purpose
- Validate inputs in `__init__` methods and raise `ValueError` for invalid inputs
- Implement `__str__`, `__eq__`, and `__hash__` methods when appropriate
- Keep methods concise and focused on a single responsibility

## Error Handling
- Use appropriate exception types (ValueError for invalid inputs)
- Include descriptive error messages that explain what went wrong
- Validate inputs early in methods

## Project Structure
- Main code in `tedesco/` package directory
- Tests in `tests/` directory
- Documentation in `docs/` directory
