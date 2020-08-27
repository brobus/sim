SRCFILES := $(wildcard *.cs)

Sim:
	mcs $(SRCFILES) -out:Sim.exe