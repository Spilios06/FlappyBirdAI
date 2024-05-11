# Flappy Bird AI

## Installation Process

```bash
git clone https://github.com/Spilios06/FlappyBirdAI.git
```

After cloning the repo, open the project in Unity, head to the package manager and add the following git packages

```bash
git+https://github.com/Unity-Technologies/ml-agents.git?path=com.unity.ml-agents#release_21
```

```bash
git+https://github.com/Unity-Technologies/ml-agents.git?path=com.unity.ml-agents.extensions#release_21
```

The repo already comes with the virtual environment I used to train my agents, but if you wish to recreate the training process then follow these steps, open up a terminal inside the parent project directory and set up a virtual python environment and install the required python packages, I personally used venv, but other virtualization environment software such as Conda and others can also be used.

```bash
python -m venv environment
```

#### If you are on Linux run:

```bash
environment/bin/activate
```

#### If you are on Windows run:

```bash
environment\Scripts\activate.ps1
```
After setting up the virtual environment install the following python packages
```bash
pip install mlagents mlagents-envs torch
```

Lastly run the following command to make sure everything has worked correctly until now:

```bash
mlagents-learn --help
```